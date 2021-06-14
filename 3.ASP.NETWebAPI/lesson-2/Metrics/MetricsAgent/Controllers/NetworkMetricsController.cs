using System;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgent.Controllers {
  [Route("api/metrics/network")]
  [ApiController]
  public class NetworkMetricsController : ControllerBase {
    [HttpGet("from/{fromTime}/to/{toTime}")]
    public IActionResult
    GetMetricsFromAgent([ FromRoute ] DateTimeOffset fromTime,
                        [ FromRoute ] DateTimeOffset toTime) {
      return Ok(new {FromTime = fromTime, ToTime = toTime});
    }
  }
}