using System;
using Microsoft.AspNetCore.Mvc;

namespace MetricsManager.Controllers
{
[Route("api/metrics/hdd")]
[ApiController]
public class HddMetricsController : ControllerBase
{
    [HttpGet("agent/{agentId:int}/left/from/{fromTime}/to/{toTime}")]
    public IActionResult GetMetricsFromAgent([FromRoute] int agentId, [FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
    {
        return Ok(new {AgentId = agentId, FromTime = fromTime, ToTime = toTime});
    }
    [HttpGet("cluster/left/from/{fromTime}/to/{toTime}")]
    public IActionResult GetMetricsFromAllCluster([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
    {
        return Ok(new {FromTime = fromTime, ToTime = toTime});
    }
}
}