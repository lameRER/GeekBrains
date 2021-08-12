using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Timesheets.DAL.Model;

namespace Timesheets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private static readonly List<Customer> ClientsRepository = new();
        
        private readonly ILogger<CustomersController> _logger;

        public CustomersController(ILogger<CustomersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ClientsRepository);
        }
        
        [HttpGet("/{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            return Ok(ClientsRepository.SingleOrDefault(item => item.Id == id));
        }

        [HttpPut("modify")]
        public IActionResult Modify([FromBody] Customer customer)
        {
            var entity = ClientsRepository.SingleOrDefault(item => item.Id == customer.Id);
            if (entity == null)
                return BadRequest($"Клиент с идентификатором {customer.Id} не найден");
            entity.Name = customer.Name;
            return Ok();
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] Customer customer)
        {
            if (ClientsRepository.Any(item => item.Name == customer.Name.Trim()))
            {
                return BadRequest($"Клиент с идентификатором {ClientsRepository.Where(item => item.Name == customer.Name.Trim()).Select(item => item.Id).First()} уже существует");
            }
            else
            {
                var maxId = (ClientsRepository.Any(item => item.Id != 0)) ? ClientsRepository.Max(item => item.Id) : 0;
                customer.Id = maxId + 1;
                ClientsRepository.Add(customer);
                return Ok($"Клиент '{customer.Name}' успешно добавлен");
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var index = ClientsRepository.FindIndex(item => item.Id == id);
            if (index == -1)
                return BadRequest($"Клиент с идентификатором {id} не найден");
            ClientsRepository.RemoveAt(index);
            return Ok();
        }
    }
}