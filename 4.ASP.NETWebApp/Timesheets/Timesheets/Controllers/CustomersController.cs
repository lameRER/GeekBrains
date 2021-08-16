using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Timesheets.DAL.Models;
using Timesheets.Request;

namespace Timesheets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private static readonly List<Customer> CustomRepository = new();

        private readonly ILogger<CustomersController> _logger;
        private readonly IMediator _mediator;

        public CustomersController(ILogger<CustomersController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await _mediator.Send(new GetCustomerQuery());
            return Ok(CustomRepository);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return Ok(CustomRepository.SingleOrDefault(item => item.Id == id));
        }

        [HttpPut("modify")]
        public async Task<IActionResult> Modify([FromBody] Customer customer)
        {
            var entity = CustomRepository.SingleOrDefault(item => item.Id == customer.Id);
            if (entity == null)
                return BadRequest($"Клиент с идентификатором {customer.Id} не найден");
            entity.Name = customer.Name;
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Customer customer)
        {
            if (CustomRepository.Any(item => item.Name == customer.Name.Trim()))
            {
                return BadRequest($"Клиент с идентификатором {CustomRepository.Where(item => item.Name == customer.Name.Trim()).Select(item => item.Id).First()} уже существует");
            }

            var maxId = (CustomRepository.Any(item => item.Id != 0)) ? CustomRepository.Max(item => item.Id) : 0;
            customer.Id = maxId + 1;
            CustomRepository.Add(customer);
            return Ok($"Клиент '{customer.Name}' успешно добавлен");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var index = CustomRepository.FindIndex(item => item.Id == id);
            if (index == -1)
                return BadRequest($"Клиент с идентификатором {id} не найден");
            CustomRepository.RemoveAt(index);
            return Ok();
        }
    }
}