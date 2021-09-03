using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Timesheets.Request;

namespace Timesheets.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
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

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> Get([FromRoute] GetCustomerByIdQuery request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("{CustomerId:int}/Contracts")]
        public async Task<IActionResult> GetCustomerContract([FromRoute] GetCustomerContractQuery request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("Contract/{ContractId:int}/Invoices/From/{DateFrom:datetime}/To/{DateTo:datetime}")]
        public async Task<IActionResult> GetContractInvoices([FromRoute] int contractId, [FromRoute] DateTime dateFrom,
            [FromRoute] DateTime dateTo)
        {
            return Ok(await _mediator.Send(new GetContractInvoicesByIdQuery { ContractId = contractId, DateFrom = dateFrom, DateTo = dateTo }));
        }

        [HttpPost("{CustomerId:int}/Contract")]
        public async Task<IActionResult> AddContract(AddContractCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPost("Contract/{ContractId:int}/Invoice")]
        public async Task<IActionResult> AddInvoice(AddInvoiceCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddCustomerCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}