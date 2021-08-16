using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Timesheets.DAL.Models;

namespace Timesheets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoicesController : ControllerBase
    {
        private static readonly List<Invoice> InvoicesRepository = new();
        
        private readonly ILogger<InvoicesController> _logger;

        public InvoicesController(ILogger<InvoicesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogDebug("");
            return Ok(InvoicesRepository);
        }

        [HttpPost("modify")]
        public IActionResult Modify([FromBody] Invoice invoice)
        {
            var entity = InvoicesRepository.SingleOrDefault(item => item.ContractId == invoice.ContractId && item.Date == invoice.Date);
            if (entity == null)
                return BadRequest($"Счет с контрактом = {invoice.ContractId}; Дата = {invoice.Date};");
            entity.Description = invoice.Description;
            entity.Total = invoice.Total;
            return Ok();
        }

        [HttpPut("add")]
        public IActionResult Add([FromBody] Invoice invoice)
        {
            if (InvoicesRepository.Any(item => item.ContractId == invoice.ContractId && item.Date == invoice.Date))
                return BadRequest($"Счет с контрактом = {invoice.ContractId}; Дата = {invoice.Date};");
            InvoicesRepository.Add(invoice);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete([FromBody] Invoice invoice)
        {
            var index = InvoicesRepository.FindIndex(item => item.ContractId == invoice.ContractId && item.Date == invoice.Date);
            if (index == -1)
                return BadRequest($"Счет с контрактом = {invoice.ContractId}; Дата = {invoice.Date};");
            InvoicesRepository.RemoveAt(index);
            return Ok();
        }
    }
}