using System;
using MetricsLogging;
using Microsoft.AspNetCore.Mvc;

namespace MetricsManager.Controllers
{
    [Route("api/metrics/dotnet")]
    [ApiController]
    public class DotNetMetricsController : ControllerBase
    {
        [HttpGet("agent/{agentId:int}/errors-count/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent([FromRoute] int agentId, [FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {
            try
            {
                return Ok(new {AgentId = agentId, FromTime = fromTime, ToTime = toTime});
            }
            catch (Exception e)
            {
                Logging.Log.Error(e);
                return BadRequest(e.Message);
            }
        }

        [HttpGet("cluster/errors-count/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAllCluster([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {
            try
            {
                return Ok(new {FromTime = fromTime, ToTime = toTime});
            }
            catch (Exception e)
            {
                Logging.Log.Error(e);
                return BadRequest(e.Message);
            }
        }
    }
}