using System;
using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MetricsAgentTest
{
    public class DotNetMetricsControllerUnitTest
    {
        private readonly DotNetMetricsController _controller;
        private readonly DateTimeOffset _fromTime;
        private readonly DateTimeOffset _toTime;

        public DotNetMetricsControllerUnitTest()
        {
            _controller = new DotNetMetricsController();
            _fromTime = new DateTimeOffset(2021, 06, new Random().Next(1, 30), new Random().Next(0, 24),
                new Random().Next(0, 60), 00, TimeSpan.FromSeconds(new Random().Next(0,100)));
            _toTime = new DateTimeOffset(2021, 06, new Random().Next(1, 30), new Random().Next(0, 24),
                new Random().Next(0, 60), 00, TimeSpan.FromSeconds(new Random().Next(0,100)));
        }
        
        [Fact]
        public void GetMetricsFromAgent_ReturnOk()
        {
            var result = _controller.GetMetricsFromAgent(_fromTime, _toTime);
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}