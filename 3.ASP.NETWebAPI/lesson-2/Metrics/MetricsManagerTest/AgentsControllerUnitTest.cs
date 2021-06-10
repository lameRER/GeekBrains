using System;
using System.Collections.Generic;
using MetricsManager;
using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MetricsManagerTest
{
public class AgentsControllerUnitTest
{
    private readonly AgentsController _controller;
    private readonly AgentInfo _agentInfo;

    public AgentsControllerUnitTest()
    {
        var agentList = new AgentsList();
        _controller = new AgentsController(agentList);
        _agentInfo = new AgentInfo(
            new Random().Next(1, 9999999),
            new Uri($"http:\\\\192.168.{new Random().Next(0,3)}.{new Random().Next(0,254)}:5000"));
    }

    [Fact]
    public void RegisterAgent_ReturnOk()
    {
        var result = _controller.RegisterAgent(_agentInfo);
        Assert.IsAssignableFrom<IActionResult>(result);
    }

    [Fact]
    public void EnableAgentById_ReturnOk()
    {
        var result = _controller.EnableAgentById(_agentInfo.AgentId);
        Assert.IsAssignableFrom<IActionResult>(result);
    }

    [Fact]
    public void DisableAgentById_ReturnOk()
    {
        var result = _controller.DisableAgentById(_agentInfo.AgentId);
        Assert.IsAssignableFrom<IActionResult>(result);
    }
}
}