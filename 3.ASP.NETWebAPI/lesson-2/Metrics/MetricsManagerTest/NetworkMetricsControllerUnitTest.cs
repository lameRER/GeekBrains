using System;
using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MetricsManagerTest
{
public class NetworkMetricsControllerUnitTest
{
    private readonly NetworkMetricsController _controller;
    private readonly int _agentId;
    private readonly DateTimeOffset _fromTime;
    private readonly DateTimeOffset _toTime;

    public NetworkMetricsControllerUnitTest()
    {
        _controller = new NetworkMetricsController();
        _agentId = new Random().Next(1, 9999999);
        _fromTime = new DateTimeOffset(2021, 06, new Random().Next(1, 30), new Random().Next(0, 24),
                                       new Random().Next(0, 60), 00, TimeSpan.Zero);
        _toTime = new DateTimeOffset(2021, 06, new Random().Next(1, 30), new Random().Next(0, 24),
                                     new Random().Next(0, 60), 00, TimeSpan.Zero);
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