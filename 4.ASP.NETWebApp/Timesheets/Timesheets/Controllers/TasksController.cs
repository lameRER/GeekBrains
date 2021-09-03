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
    [Route("Api/[controller]")]
    public class TasksController : Controller
    {
        private readonly ILogger<TasksController> _logger;
        private readonly IMediator _mediator;

        public TasksController(ILogger<TasksController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetTasksQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddTaskCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}