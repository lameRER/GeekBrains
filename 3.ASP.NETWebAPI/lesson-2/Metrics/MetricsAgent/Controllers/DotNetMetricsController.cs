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
    [Route("api/metrics/dotnet")]
    [ApiController]
    public class DotNetMetricsController : ControllerBase
    {
        private readonly IDotNetMetricsRepository _repository;

        private readonly ILogger _logger;

        public DotNetMetricsController(IDotNetMetricsRepository repository, ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("errors-count/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {
            try
            {
                _logger.Debug($"Route(api/metrics/dotnet): Running the GetMetricsFromAgent method");
                var metrics = _repository.GetByPeriod(fromTime, toTime);
                var response = new MetricsResponse<DotNetMetricsDto>();
                foreach (var item in metrics)
                {
                    response.Metrics.Add(new DotNetMetricsDto
                    {
                        Id = item.Id,
                        Value = item.Value,
                        Time = item.Time
                    });
                }
                _logger.Debug($"Route(api/metrics/dotnet): GetMetricsFromAgent method completed successfully");
                return Ok(response.Metrics.ToList());
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] DotNetMetricCreateRequest metric)
        {
            try
            {
                _logger.Debug($"Route(api/metrics/dotnet): Running the Create method");
                _repository.Create(new DotNetMetric
                {
                    Value = metric.Value,
                    Time = metric.Time,
                });
                _logger.Debug($"Route(api/metrics/dotnet): Create method completed successfully");
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