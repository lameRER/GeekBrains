using System;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgent.Controllers {
  [Route("api/metrics/ram")]
  [ApiController]
  public class RamMetricsController : ControllerBase {
    [HttpGet("available/from/{fromTime}/to/{toTime}")]
    public IActionResult GetMetricsFromAgent([ FromRoute ] TimeSpan fromTime,
                                             [ FromRoute ] TimeSpan toTime) {
      return Ok(new {FromTime = fromTime, ToTime = toTime});
    }
  }
}
