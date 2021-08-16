using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Timesheets.DAL.Models;

namespace Timesheets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractsController : ControllerBase
    {
        private static readonly List<Contract> ContractsRepository = new();
        
        private readonly ILogger<ContractsController> _logger;

        public ContractsController(ILogger<ContractsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogDebug("");
            return Ok(ContractsRepository);
        }

        [HttpPost("modify")]
        public IActionResult Modify([FromBody] Contract contract)
        {
            var entity = ContractsRepository.SingleOrDefault(item => item.Id == contract.Id);
            if (entity == null)
                return BadRequest($"Контракт с идентификатором {contract.Id} не найден");
            entity.Name = contract.Name;
            entity.SetDate = contract.SetDate;
            entity.EndDate = contract.EndDate;
            entity.CustomerId = contract.CustomerId;
            entity.Number = contract.Number;
            return Ok();
        }

        [HttpPut("add")]
        public IActionResult Add([FromBody] Contract contract)
        {
            if (ContractsRepository.Any(item => item.Name == contract.Name.Trim()))
                return BadRequest($"Контракт с идентификатором {contract.Id} уже существует");
            var maxId = ContractsRepository.Max(item => item.Id);
            contract.Id = maxId + 1;
            ContractsRepository.Add(contract);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var index = ContractsRepository.FindIndex(item => item.Id == id);
            if (index == -1)
                return BadRequest($"Контракт с идентификатором {id} не найден");
            ContractsRepository.RemoveAt(index);
            return Ok();
        }
    }
}