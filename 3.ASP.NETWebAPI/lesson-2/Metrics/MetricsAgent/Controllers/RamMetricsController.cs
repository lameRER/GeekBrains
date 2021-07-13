using System;
using System.Linq;
using AutoMapper;
using MetricsAgent.DAL.Interface;
using MetricsAgent.DAL.Model;
using MetricsAgent.DAL.Responses;
using MetricsAgent.Request;
using NLog;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/ram")]
    [ApiController]
    public class RamMetricsController : ControllerBase
    {
        private readonly IRamMetricsRepository _repository;

        private readonly ILogger _logger;

        private readonly IMapper _mapper;

        public RamMetricsController(IRamMetricsRepository repository, ILogger logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("available/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {
            try
            {
                _logger.Debug($"Route(api/metrics/ram): Running the GetMetricsFromAgent method");
                var metrics = _repository.GetByPeriod(fromTime, toTime);
                var response = new MetricsResponse<RamMetricsDto>();
                foreach (var item in metrics)
                {
                    response.Metrics.Add(_mapper.Map<RamMetricsDto>(item));
                }
                _logger.Debug($"Route(api/metrics/ram): GetMetricsFromAgent method completed successfully");
                return Ok(response.Metrics.ToList());
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] RamMetricCreateRequest metric)
        {
            try
            {
                _logger.Debug($"Route(api/metrics/ram): Running the Create method");
                _repository.Create(_mapper.Map<RamMetric>(metric));
                _logger.Debug($"Route(api/metrics/ram): Create method completed successfully");
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