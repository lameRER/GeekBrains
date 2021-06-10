using System;
using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MetricsManagerTest
{
    public class RamMetricsControllerUnitTest
    {
        private readonly RamMetricsController _controller;
        private readonly int _agentId;
        private readonly TimeSpan _fromTime;
        private readonly TimeSpan _toTime;

        public RamMetricsControllerUnitTest()
        {
            _controller = new RamMetricsController();
            _agentId = new Random().Next(1, 9999999);
            _fromTime = TimeSpan.FromSeconds(new Random().Next(0, 100));
            _toTime = TimeSpan.FromSeconds(new Random().Next(101, 200));
        }

        [Fact]
        public void GetMetricsFromAgent_ReturnOk()
        {
            var result = _controller.GetMetricsFromAgent(_agentId, _fromTime, _toTime);
            Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void GetMetricsFromAllCluster_ReturnOk()
        {
            var result = _controller.GetMetricsFromAllCluster(_fromTime, _toTime);
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}