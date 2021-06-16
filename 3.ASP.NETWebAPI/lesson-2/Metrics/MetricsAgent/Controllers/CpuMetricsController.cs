using System;
using System.Linq;
using MetricsAgent.DAL;
using MetricsAgent.DAL.Interface;
using MetricsAgent.DAL.Model;
using MetricsAgent.DAL.Responses;
using MetricsAgent.Request;
using Microsoft.AspNetCore.Mvc;
using MetricsLogging;
using Microsoft.AspNetCore.Routing;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/cpu")]
    [ApiController]
    public class CpuMetricsController : ControllerBase
    {
        private readonly ICpuMetricsRepository _repository;

        public CpuMetricsController(ICpuMetricsRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {
            try
            {
                Logging.Log.Debug($"Route(api/metrics/cpu): Running the GetMetricsFromAgent method");
                var metrics = _repository.GetByPeriod(fromTime, toTime);
                var response = new MetricsResponse<CpuMetricDto>();
                foreach (var item in metrics)
                {
                    response.Metrics.Add(new CpuMetricDto
                    {
                        Id = item.Id,
                        Value = item.Value,
                        Time = item.Time
                    });
                }
                Logging.Log.Debug($"Route(api/metrics/cpu): GetMetricsFromAgent method completed successfully");
                return Ok(response.Metrics.ToList());
            }
            catch (Exception e)
            {
                Logging.Log.Error(e);
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] CpuMetricCreateRequest metric)
        {
            try
            {
                Logging.Log.Debug($"Route(api/metrics/cpu): Running the Create method");
                _repository.Create(new CpuMetric
                {
                    Value = metric.Value,
                    Time = metric.Time,
                });
                Logging.Log.Debug($"Route(api/metrics/cpu): Create method completed successfully");
                return Ok();
            }
            catch (Exception e)
            {
                Logging.Log.Error(e);
                return BadRequest(e.Message);
            }
        }
    }
}