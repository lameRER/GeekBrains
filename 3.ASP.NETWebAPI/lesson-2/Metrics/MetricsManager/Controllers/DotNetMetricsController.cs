using System;
using Microsoft.AspNetCore.Mvc;

namespace MetricsManager.Controllers {
  [Route("api/metrics/dotnet")]
  [ApiController]
  public class DotNetMetricsController : ControllerBase {
    [HttpGet("agent/{agentId:int}/errors-count/from/{fromTime}/to/{toTime}")]
    public IActionResult GetMetricsFromAgent([ FromRoute ] int agentId,
                                             [ FromRoute ] TimeSpan fromTime,
                                             [ FromRoute ] TimeSpan toTime) {
      return Ok(new {AgentId = agentId, FromTime = fromTime, ToTime = toTime});
    }

    [HttpGet("cluster/errors-count/from/{fromTime}/to/{toTime}")]
    public IActionResult
    GetMetricsFromAllCluster([ FromRoute ] TimeSpan fromTime,
                             [ FromRoute ] TimeSpan toTime) {
      return Ok(new {FromTime = fromTime, ToTime = toTime});
    }
  }
}