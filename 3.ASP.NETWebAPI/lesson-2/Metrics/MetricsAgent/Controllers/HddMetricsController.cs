using System;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgent.Controllers {
  [Route("api/metrics/hdd")]
  [ApiController]
  public class HddMetricsController : ControllerBase {
    [HttpGet("left/from/{fromTime}/to/{toTime}")]
    public IActionResult
    GetMetricsFromAgent([ FromRoute ] DateTimeOffset fromTime,
                        [ FromRoute ] DateTimeOffset toTime) {
      return Ok(new {FromTime = fromTime, ToTime = toTime});
    }
  }
}