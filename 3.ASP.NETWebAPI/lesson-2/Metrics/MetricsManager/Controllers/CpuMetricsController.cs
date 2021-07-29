using System;
using System.Collections.Generic;
using AutoMapper;
using MetricsManager.DAL.Interface;
using MetricsManager.Responses.Metrics;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace MetricsManager.Controllers
{
    [Route("api/metrics/cpu")]
    [ApiController]
    public class CpuMetricsController : ControllerBase
    {
        private readonly ILogger _logger;

        private ICpuMetricsRepository _repository;

        private readonly IMapper _mapper;

        public CpuMetricsController(ILogger logger, ICpuMetricsRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("agent/{agentId:int}/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent([FromRoute] int agentId, [FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {
            try
            {
                var metricslist = _repository.GetByPeriodFormAgent(agentId, fromTime, toTime);
                var response = new MetricResponse<CpuMetricsDto>();
                response.Metrics.AddRange(_mapper.Map<List<CpuMetricsDto>>(metricslist));
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAllCluster([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {
            try
            {
                var metricslist = _repository.GetByPeriod(fromTime, toTime);
                var response = new MetricResponse<CpuMetricsDto>();
                response.Metrics.AddRange(_mapper.Map<List<CpuMetricsDto>>(metricslist));
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return BadRequest(e.Message);
            }
        }
    }
}