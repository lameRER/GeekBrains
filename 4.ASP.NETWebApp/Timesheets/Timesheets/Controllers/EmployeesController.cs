using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Timesheets.DAL.Model;

namespace Timesheets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private static readonly List<Employee> EmployeesRepository = new();
        
        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController(ILogger<EmployeesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogDebug("");
            return Ok(EmployeesRepository);
        }

        [HttpPost("modify")]
        public IActionResult Modify([FromBody] Employee employee)
        {
            var entity = EmployeesRepository.SingleOrDefault(item => item.Id == employee.Id);
            if (entity == null)
                return BadRequest($"Сотрудник с идентификатором {employee.Id} не найден");
            entity.Name = employee.Name;
            return Ok();
        }

        [HttpPut("add")]
        public IActionResult Add([FromBody] Employee employee)
        {
            if (EmployeesRepository.Any(item => item.Name == employee.Name.Trim()))
                return BadRequest($"Сотрудник с идентификатором {employee.Id} уже существует.");
            var maxId = EmployeesRepository.Max(item => item.Id);
            employee.Id = maxId + 1;
            EmployeesRepository.Add(employee);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var index = EmployeesRepository.FindIndex(item => item.Id == id);
            if (index == -1)
                return BadRequest($"Сотрудник с идентификатором {id} не найден");
            EmployeesRepository.RemoveAt(index);
            return Ok();
        }
    }
}