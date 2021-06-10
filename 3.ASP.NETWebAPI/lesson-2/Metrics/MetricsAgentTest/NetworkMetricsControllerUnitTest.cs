using System;
using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MetricsAgentTest
{
public class NetworkMetricsControllerUnitTest
{
    private readonly NetworkMetricsController _controller;
    private readonly TimeSpan _fromTime;
    private readonly TimeSpan _toTime;

    public NetworkMetricsControllerUnitTest()
    {
        _controller = new NetworkMetricsController();
        _fromTime = TimeSpan.FromSeconds(new Random().Next(0, 100));
        _toTime = TimeSpan.FromSeconds(new Random().Next(101, 200));
    }

    [Fact]
    public void GetMetricsFromAgent_ReturnOk()
    {
        var result = _controller.GetMetricsFromAgent(_fromTime, _toTime);
        Assert.IsAssignableFrom<IActionResult>(result);
    }
}
}