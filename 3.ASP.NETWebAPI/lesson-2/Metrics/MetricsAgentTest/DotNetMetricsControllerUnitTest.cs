using System;
using AutoMapper;
using MetricsAgent.Controllers;
using MetricsAgent.DAL.Interface;
using MetricsAgent.DAL.Model;
using MetricsAgent.Request;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NLog;
using Xunit;

namespace MetricsAgentTest
{
    public class DotNetMetricsControllerUnitTest
    {
        private readonly DotNetMetricsController _controller;
        private readonly DateTimeOffset _time;
        private readonly Mock<IDotNetMetricsRepository> _mock;

        public DotNetMetricsControllerUnitTest()
        {
            var logger = new Mock<ILogger>();
            var mapper = new Mock<IMapper>();
            _mock = new Mock<IDotNetMetricsRepository>();
            _controller = new DotNetMetricsController(_mock.Object, logger.Object, mapper.Object);
            _time = new DateTimeOffset(2021, 06, new Random().Next(1, 30), new Random().Next(0, 24),
                new Random().Next(0, 60), 00, TimeSpan.Zero);
        }
        
        [Fact]
        public void GetMetricsFromAgent_ReturnOk()
        {
            _mock.Setup(repository => repository.Create(It.IsAny<DotNetMetric>())).Verifiable();
            var result = _controller.Create(new DotNetMetricCreateRequest()
                {Time = _time, Value = new Random().Next(0, 100)});
            _mock.Verify(repository => repository.Create(It.IsAny<DotNetMetric>()), Times.AtMostOnce);
        }
        
        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            _mock.Setup(repository => repository.Create(It.IsAny<DotNetMetric>())).Verifiable();
            var result = _controller.Create(new DotNetMetricCreateRequest()
                {Time = _time, Value = new Random().Next(0, 100)});
            _mock.Verify(repository => repository.Create(It.IsAny<DotNetMetric>()), Times.AtMostOnce);
        }

        [Fact]
        public void GetMetricsFromAgent_ShouldCall_Create_From_Repository()
        {
            var request = new DotNetMetricCreateRequest() {Value = new Random().Next(0, 100), Time = DateTimeOffset.Now};
            var result = _controller.Create(request);
            _mock.Verify(repository => repository.GetByPeriod(It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()), Times.AtMostOnce);
        }
    }
}