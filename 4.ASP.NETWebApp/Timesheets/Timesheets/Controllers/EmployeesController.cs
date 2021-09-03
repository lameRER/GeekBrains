using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Timesheets.Service.Request;

namespace Timesheets.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;
        private readonly IMediator _mediator;

        public EmployeesController(ILogger<EmployeesController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetEmployeesQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddEmployeeCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
        
        [HttpGet("{EmployeeId:int}/Executions")]
        public async Task<IActionResult> GetEmployeeExecutions([FromRoute] GetEmployeeExecutionsQuery request)
        {
            return Ok(await _mediator.Send(request));
        }
        
        [HttpPost("{EmployeeId:int}/Task/{TaskId:int}/Execution/{TimeSpent:int}")]
        public async Task<IActionResult> AddEmployeeTaskExecution([FromRoute] AddEmployeeTaskExecutionCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}