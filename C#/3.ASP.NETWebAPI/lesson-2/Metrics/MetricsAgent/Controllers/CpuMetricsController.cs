using System;
using System.Linq;
using AutoMapper;
using MetricsAgent.DAL;
using MetricsAgent.DAL.Interface;
using MetricsAgent.DAL.Model;
using MetricsAgent.DAL.Responses;
using MetricsAgent.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using NLog;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/cpu")]
    [ApiController]
    public class CpuMetricsController : ControllerBase
    {
        private readonly ICpuMetricsRepository _repository;

        private readonly ILogger _logger;

        private readonly IMapper _mapper;

        public CpuMetricsController(ICpuMetricsRepository repository, ILogger logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {
            try
            {
                _logger.Debug($"Route(api/metrics/cpu): Running the GetMetricsFromAgent method");
                var metrics = _repository.GetByPeriod(fromTime, toTime);
                var response = new MetricsResponse<CpuMetricDto>();
                foreach (var item in metrics)
                {
                    response.Metrics.Add(_mapper.Map<CpuMetricDto>(item));
                }
                _logger.Debug($"Route(api/metrics/cpu): GetMetricsFromAgent method completed successfully");
                return Ok(response.Metrics.ToList());
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] CpuMetricCreateRequest metric)
        {
            try
            {
                _logger.Debug($"Route(api/metrics/cpu): Running the Create method");
                _repository.Create(_mapper.Map<CpuMetric>(metric));
                _logger.Debug($"Route(api/metrics/cpu): Create method completed successfully");
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