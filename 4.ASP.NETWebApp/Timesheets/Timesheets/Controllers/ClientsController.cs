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
    public class ClientsController : ControllerBase
    {
        private static readonly List<Client> ClientsRepository = new();
        private readonly ILogger<ClientsController> _logger;

        public ClientsController(ILogger<ClientsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ClientsRepository);
        }

        [HttpPost("modify")]
        public IActionResult Modify([FromBody]Client Client)
        {
            var entity = ClientsRepository.SingleOrDefault(item => item.Id == Client.Id);
            if (entity == null)
                return BadRequest($"Клиент с идентификатором {Client.Id} не найден");
            entity.Name = Client.Name;
            return Ok();
        }

        [HttpPut("add")]
        public IActionResult Add([FromBody]Client Client)
        {
            if (ClientsRepository.Any(item => item.Name == Client.Name.Trim()))
                return BadRequest($"Клиент с идентификатором {Client.Id} уже существует");
            var maxId = ClientsRepository.Max(item => item.Id);
            Client.Id = maxId + 1;
            ClientsRepository.Add(Client);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            var index = ClientsRepository.FindIndex(item => item.Id == id);
            if (index == -1)
                return BadRequest($"Клиент с идентификатором {id} не найден");
            ClientsRepository.RemoveAt(index);
            return Ok();
        }
    }
}