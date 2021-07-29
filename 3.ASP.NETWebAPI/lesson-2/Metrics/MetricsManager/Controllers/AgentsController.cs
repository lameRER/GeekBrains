using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MetricsManager.Client.Requests;
using MetricsManager.DAL.Interface;
using MetricsManager.Responses.Agents;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace MetricsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        private readonly IAgentsRepository _repository;

        private readonly ILogger _logger;

        private readonly IMapper _mapper;
        
        public AgentsController(ILogger logger, IMapper mapper, IAgentsRepository repository)
        {
            try
            {
                _repository = repository;
                _logger = logger;
                _mapper = mapper;
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }
        }
        
        [HttpGet]
        public IActionResult GetRegisteredAgents()
        {
            try
            {
                var agentsList = _repository.GetRegistered();
                var response = new AgentInfoResponse();
                response.Agengs.AddRange(_mapper.Map<List<AgentInfoDto>>(agentsList));
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return BadRequest(e.Message);
            }
        }
        
        [HttpPost("register")]
        public IActionResult RegisterAgent([FromBody] AgentInfoRequest agentInfo)
        {
            _repository.Create(_mapper.Map<AgentInfo>(agentInfo));
            // _agentList.AgentInfos.Add(agentInfo);
            return Ok(agentInfo);
        }

        [HttpPut("enable/{agentId:int}")]
        public IActionResult EnableAgentById([FromRoute] int agentId)
        {
            try
            {
                _repository.EnableById(agentId);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return BadRequest(e.Message);
            }
        }

        [HttpPut("disable/{agentId:int}")]
        public IActionResult DisableAgentById([FromRoute] int agentId)
        {
            try
            {
                _repository.DisableById(agentId);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return BadRequest(e.Message);
            }
        }
    }
}