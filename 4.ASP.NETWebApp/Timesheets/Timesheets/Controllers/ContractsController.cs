using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Timesheets.DAL.Model;

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
        public IActionResult Modify([FromBody] Contract Contract)
        {
            var entity = ContractsRepository.SingleOrDefault(item => item.Id == Contract.Id);
            if (entity == null)
                return BadRequest($"Контракт с идентификатором {Contract.Id} не найден");
            entity.Name = Contract.Name;
            entity.Date = Contract.Date;
            entity.ClientId = Contract.ClientId;
            entity.Number = Contract.Number;
            return Ok();
        }

        [HttpPut("add")]
        public IActionResult Add([FromBody] Contract Contract)
        {
            if (ContractsRepository.Any(item => item.Name == Contract.Name.Trim()))
                return BadRequest($"Контракт с идентификатором {Contract.Id} уже существует");
            var maxId = ContractsRepository.Max(item => item.Id);
            Contract.Id = maxId + 1;
            ContractsRepository.Add(Contract);
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