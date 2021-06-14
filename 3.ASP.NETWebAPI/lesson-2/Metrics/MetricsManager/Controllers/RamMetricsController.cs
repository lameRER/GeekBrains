using System;
using Microsoft.AspNetCore.Mvc;

namespace MetricsManager.Controllers {
  [Route("api/metrics/ram")]
  [ApiController]
  public class RamMetricsController : ControllerBase {
    [HttpGet("agent/{agentId:int}/available/from/{fromTime}/to/{toTime}")]
    public IActionResult
    GetMetricsFromAgent([ FromRoute ] int agentId,
                        [ FromRoute ] DateTimeOffset fromTime,
                        [ FromRoute ] DateTimeOffset toTime) {
      return Ok(new {AgentId = agentId, FromTime = fromTime, ToTime = toTime});
    }
    [HttpGet("cluster/available/from/{fromTime}/to/{toTime}")]
    public IActionResult
    GetMetricsFromAllCluster([ FromRoute ] DateTimeOffset fromTime,
                             [ FromRoute ] DateTimeOffset toTime) {
      return Ok(new {FromTime = fromTime, ToTime = toTime});
    }
  }
}
