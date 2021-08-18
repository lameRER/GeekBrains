using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Timesheets.DAL.Models;
using Timesheets.Request;
using Task = System.Threading.Tasks.Task;

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
            return Ok(await _mediator.Send(new GetCustomerQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetCustomerByIdQuery(id));
            return Ok(response);
            // return Ok(CustomRepository.SingleOrDefault(item => item.Id == id));
        }

        [HttpGet("{CustomerId}/Contracts")]
        public async Task<IActionResult> GetCustomerContract([FromRoute] GetCustomerContractQuery request)
        {
            return Ok();
        }

        [HttpGet("Contract/{ContractId}/Invoices/From/{DateFrom}/To/{DateTo}")]
        public async Task<IActionResult> GetContractInvoices([FromRoute] int ContractId, [FromRoute] DateTime DateFrom,
            [FromRoute] DateTime DateTo)
        {
            return Ok();
        }

        [HttpPost("{CustomerId}/Contract")]
        public async Task<IActionResult> AddContract(AddContractCommand request)
        {
            return Ok();
        }

        [HttpPost("Contract/{ContractId}/Invoice")]
        public async Task<IActionResult> AddInvoice(AddInvoiceCommand request)
        {
            return Ok();
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
        public async Task<IActionResult> Add([FromBody] AddCustomerQuery request)
        {
            return Ok(await _mediator.Send(request));
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