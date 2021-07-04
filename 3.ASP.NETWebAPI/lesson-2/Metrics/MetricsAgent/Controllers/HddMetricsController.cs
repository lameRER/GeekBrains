using System;
using System.Linq;
using MetricsAgent.DAL.Interface;
using MetricsAgent.DAL.Model;
using MetricsAgent.DAL.Responses;
using MetricsAgent.Request;
using NLog;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/hdd")]
    [ApiController]
    public class HddMetricsController : ControllerBase
    {
        private readonly IHddMetricsRepository _repository;

        private readonly ILogger _logger;

        public HddMetricsController(IHddMetricsRepository repository, ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }
        
        [HttpGet("left/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {
            try
            {
                _logger.Debug($"Route(api/metrics/hdd): Running the GetMetricsFromAgent method");
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
                _logger.Debug($"Route(api/metrics/hdd): GetMetricsFromAgent method completed successfully");
                return Ok(response.Metrics.ToList());
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] HddMetricCreateRequest metric)
        {
            try
            {
                _logger.Debug($"Route(api/metrics/hdd): Running the Create method");
                _repository.Create(new HddMetric
                {
                    Value = metric.Value,
                    Time = metric.Time,
                });
                _logger.Debug($"Route(api/metrics/hdd): Create method completed successfully");
                return Ok();
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return BadRequest(e.Message);
            }
        }
    }
}