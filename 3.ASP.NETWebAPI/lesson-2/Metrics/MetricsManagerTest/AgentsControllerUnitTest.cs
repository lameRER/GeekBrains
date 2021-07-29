using System;
using System.Collections.Generic;
using AutoMapper;
using MetricsManager;
using MetricsManager.Client.Requests;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using NLog;
using MetricsManager.Controllers;
using MetricsManager.DAL.Interface;
using MetricsManager.Responses.Agents;

namespace MetricsManagerTest
{
    public class AgentsControllerUnitTest
    {
        private readonly AgentsController _controller;
        private readonly Mock<IAgentsRepository> _agentsRepository;

        public AgentsControllerUnitTest(Mock<ILogger> moskLogger, Mock<IMapper> mapper, Mock<IAgentsRepository> agentsRepository, AgentsList agentsList)
        {
            _agentsRepository = agentsRepository;
            _controller = new AgentsController(moskLogger.Object, mapper.Object, agentsRepository.Object);
        }

        [Fact]
        public void GetRegisteredAgents_ReturnOk()
        {
            var url = new Uri("hhtps://localhost:5002");
            var agentsList = _agentsRepository.Setup(repository => repository.GetRegistered());
            var response = new AgentInfoResponse();
            _agentsRepository.Verify(repository => repository.Create(It.IsAny<AgentInfo>()), Times.AtMostOnce);
        }
        
        [Fact]
        public void RegisterAgent_ReturnOk()
        {
            var url = new Uri("hhtps://localhost:5002");
            _agentsRepository.Setup(repository => repository.Create(It.IsAny<AgentInfo>())).Verifiable();
            _controller.RegisterAgent(new AgentInfoRequest()
            {
                AgentAddress = url,
                IsEnabled = false
            });
            _agentsRepository.Verify(repository => repository.Create(It.IsAny<AgentInfo>()), Times.AtMostOnce);
        }
        //
        // [Fact]
        // public void EnableAgentById_ReturnOk()
        // {
        //     var result = _controller.EnableAgentById(_agentInfo.AgentId);
        //     Assert.IsAssignableFrom<IActionResult>(result);
        // }
        //
        // [Fact]
        // public void DisableAgentById_ReturnOk()
        // {
        //     var result = _controller.DisableAgentById(_agentInfo.AgentId);
        //     Assert.IsAssignableFrom<IActionResult>(result);
        // }
    }
}