using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Timesheets.DAL.Model;

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
        public IActionResult Modify([FromBody] Invoice Invoice)
        {
            var entity = InvoicesRepository.SingleOrDefault(item => item.ContractId == Invoice.ContractId && item.Date == Invoice.Date);
            if (entity == null)
                return BadRequest($"Счет с контрактом = {Invoice.ContractId}; Дата = {Invoice.Date};");
            entity.Description = Invoice.Description;
            entity.Total = Invoice.Total;
            return Ok();
        }

        [HttpPut("add")]
        public IActionResult Add([FromBody] Invoice Invoice)
        {
            if (InvoicesRepository.Any(item => item.ContractId == Invoice.ContractId && item.Date == Invoice.Date))
                return BadRequest($"Счет с контрактом = {Invoice.ContractId}; Дата = {Invoice.Date};");
            InvoicesRepository.Add(Invoice);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete([FromBody] Invoice Invoice)
        {
            var index = InvoicesRepository.FindIndex(item => item.ContractId == Invoice.ContractId && item.Date == Invoice.Date);
            if (index == -1)
                return BadRequest($"Счет с контрактом = {Invoice.ContractId}; Дата = {Invoice.Date};");
            InvoicesRepository.RemoveAt(index);
            return Ok();
        }
    }
}