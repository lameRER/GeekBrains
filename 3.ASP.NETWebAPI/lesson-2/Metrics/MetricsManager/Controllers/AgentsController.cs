using System;
using System.Collections.Generic;
using System.Linq;
using MetricsLogging;
using Microsoft.AspNetCore.Mvc;

namespace MetricsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        private readonly AgentsList _agentList;
        
        public AgentsController(AgentsList agentList)
        {
            try
            {
                _agentList = agentList;
            }
            catch (Exception e)
            {
                Logging.Log.Error(e);
            }
        }
        
        [HttpGet]
        public IActionResult GetRegisteredAgents()
        {
            try
            {
                return Ok(_agentList.AgentInfos.ToList());
            }
            catch (Exception e)
            {
                Logging.Log.Error(e);
                return BadRequest(e.Message);
            }
        }
        
        [HttpPost("register")]
        public IActionResult RegisterAgent([FromBody] AgentInfo agentInfo)
        {
            _agentList.AgentInfos.Add(agentInfo);
            return Ok();
        }

        [HttpPut("enable/{agentId:int}")]
        public IActionResult EnableAgentById([FromRoute] int agentId)
        {
            try
            {
                return Ok(_agentList.AgentInfos.Where(item => item.AgentId == agentId));
            }
            catch (Exception e)
            {
                Logging.Log.Error(e);
                return BadRequest(e.Message);
            }
        }

        [HttpPut("disable/{agentId:int}")]
        public IActionResult DisableAgentById([FromRoute] int agentId)
        {
            try
            {
                return Ok(_agentList.AgentInfos.Where(item => item.AgentId == agentId));
            }
            catch (Exception e)
            {
                Logging.Log.Error(e);
                return BadRequest(e.Message);
            }
        }
    }
}