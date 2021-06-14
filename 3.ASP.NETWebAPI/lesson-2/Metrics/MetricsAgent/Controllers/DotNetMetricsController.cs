using System;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgent.Controllers {
  [Route("api/metrics/dotnet")]
  [ApiController]
  public class DotNetMetricsController : ControllerBase {
    [HttpGet("errors-count/from/{fromTime}/to/{toTime}")]
    public IActionResult
    GetMetricsFromAgent([ FromRoute ] DateTimeOffset fromTime,
                        [ FromRoute ] DateTimeOffset toTime) {
      return Ok(new {FromTime = fromTime, ToTime = toTime});
    }
  }
}
