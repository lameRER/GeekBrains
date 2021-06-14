using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace MetricsManager.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class AgentsController : ControllerBase {
    private readonly AgentsList _agentList;

    public AgentsController(AgentsList agentList) { _agentList = agentList; }

    [HttpGet]
    public IActionResult GetRegisteredAgents() {
      return Ok(_agentList.AgentInfos.ToList());
    }

    [HttpPost("register")]
    public IActionResult RegisterAgent([ FromBody ] AgentInfo agentInfo) {
      _agentList.AgentInfos.Add(agentInfo);
      return Ok();
    }

    [HttpPut("enable/{agentId:int}")]
    public IActionResult EnableAgentById([ FromRoute ] int agentId) {
      return Ok(_agentList.AgentInfos.Where(item => item.AgentId == agentId));
    }

    [HttpPut("disable/{agentId:int}")]
    public IActionResult DisableAgentById([ FromRoute ] int agentId) {
      return Ok(_agentList.AgentInfos.Where(item => item.AgentId == agentId));
    }
  }
}
