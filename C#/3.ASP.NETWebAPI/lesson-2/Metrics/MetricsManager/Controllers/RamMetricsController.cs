using System;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace MetricsManager.Controllers
{
    [Route("api/metrics/ram")]
    [ApiController]
    public class RamMetricsController : ControllerBase
    {
        private readonly ILogger _logger;

        public RamMetricsController(ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet("agent/{agentId:int}/available/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent([FromRoute] int agentId, [FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {
            try
            {
                return Ok(new {AgentId = agentId, FromTime = fromTime, ToTime = toTime});
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return BadRequest(e.Message);
            }
        }
        [HttpGet("cluster/available/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAllCluster([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {
            try
            {
                return Ok(new {FromTime = fromTime, ToTime = toTime});
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return BadRequest(e.Message);
            }
        }
    }
}