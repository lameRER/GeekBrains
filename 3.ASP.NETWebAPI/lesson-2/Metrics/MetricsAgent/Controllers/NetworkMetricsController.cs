using System;
using System.Linq;
using MetricsAgent.DAL.Interface;
using MetricsAgent.DAL.Model;
using MetricsAgent.DAL.Responses;
using MetricsAgent.Request;
using MetricsLogging;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/network")]
    [ApiController]
    public class NetworkMetricsController : ControllerBase
    {
        private readonly INetworkMetricsRepository _repository;

        public NetworkMetricsController(INetworkMetricsRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {
            try
            {
                Logging.Log.Debug($"Route(api/metrics/network): Running the GetMetricsFromAgent method");
                var metrics = _repository.GetByPeriod(fromTime, toTime);
                var response = new MetricsResponse<HddMetricsDto>();
                foreach (var item in metrics)
                {
                    response.Metrics.Add(new HddMetricsDto
                    {
                        Id = item.Id,
                        Value = item.Value,
                        Time = item.Time
                    });
                }
                Logging.Log.Debug($"Route(api/metrics/network): GetMetricsFromAgent method completed successfully");
                return Ok(response.Metrics.ToList());
            }
            catch (Exception e)
            {
                Logging.Log.Error(e);
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] NetworkMetricCreateRequest metric)
        {
            try
            {
                Logging.Log.Debug($"Route(api/metrics/network): Running the Create method");
                _repository.Create(new NetworkMetric
                {
                    Value = metric.Value,
                    Time = metric.Time,
                });
                Logging.Log.Debug($"Route(api/metrics/network): Create method completed successfully");
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