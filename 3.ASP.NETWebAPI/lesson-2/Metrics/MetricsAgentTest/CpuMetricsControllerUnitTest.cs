using System;
using System.Collections.Generic;
using MetricsAgent.Controllers;
using MetricsAgent.DAL.Interface;
using MetricsAgent.DAL.Model;
using MetricsAgent.Request;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace MetricsAgentTest
{
    public class CpuMetricsControllerUnitTest
    {
        private readonly CpuMetricsController _controller;
        private readonly DateTimeOffset _fromTime;
        private readonly DateTimeOffset _toTime;
        private readonly Mock<ICpuMetricsRepository> _mock;

        public CpuMetricsControllerUnitTest()
        {
            _mock = new Mock<ICpuMetricsRepository>();
            _controller = new CpuMetricsController(_mock.Object);
            _fromTime = new DateTimeOffset(2021, 06, new Random().Next(1, 30), new Random().Next(0, 24),
                new Random().Next(0, 60), 00, TimeSpan.Zero);
            _toTime = new DateTimeOffset(2021, 06, new Random().Next(1, 30), new Random().Next(0, 24),
                new Random().Next(0, 60), 00, TimeSpan.Zero);
        }
        
        [Fact]
        public void GetMetricsFromAgent_ReturnOk()
        {
            var result = _controller.GetMetricsFromAgent(_fromTime, _toTime);
            Assert.IsAssignableFrom<IActionResult>(result);
        }
        
        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            _mock.Setup(repository => repository.Create(It.IsAny<CpuMetric>())).Verifiable();
            var result = _controller.Create(new CpuMetricCreateRequest()
                {Time = _fromTime, Value = new Random().Next(0, 100)});
            _mock.Verify(repository => repository.Create(It.IsAny<CpuMetric>()), Times.AtMostOnce);
        }

        [Fact]
        public void GetMetricsFromAgent_ShouldCall_Create_From_Repository()
        {
            var request = new CpuMetricCreateRequest() {Value = new Random().Next(0, 100), Time = DateTimeOffset.Now};
            var result = _controller.Create(request);
            _mock.Verify(repository => repository.GetByPeriod(It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()), Times.AtMostOnce);
        }
    }
}