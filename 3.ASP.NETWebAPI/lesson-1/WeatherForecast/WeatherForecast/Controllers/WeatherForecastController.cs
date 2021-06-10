using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace WeatherForecast.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly WeatherForecast _weatherForecast;
        

        public WeatherForecastController(WeatherForecast weatherForecast)
        {
            _weatherForecast = weatherForecast;
        }

        
        [HttpGet]
        public List<DateTemperatures> Get()
        {
            return _weatherForecast.TemperaturesList.ToList();
        }
        

        [HttpPost("create")]
        public IActionResult Create([FromQuery] DateTime dateTime, [FromQuery] int temperature)
        {
            if(Verification(temperature)) return NotFound("температура не может быть ниже -273 по Цельсию");
            _weatherForecast.TemperaturesList.Add(new DateTemperatures(dateTime, temperature));
            return Ok();
        }

        
        [HttpGet("read")]
        public IActionResult Read([FromQuery] DateTime fromDateTime, [FromQuery] DateTime toDateTime)
        {
            return Ok(_weatherForecast.TemperaturesList.Where(item =>
                item.Date >= fromDateTime && item.Date <= toDateTime));
        }
        

        [HttpPut("update")]
        public IActionResult Update([FromQuery] DateTime dateTime, [FromQuery] int temperature)
        {
            if (Verification(temperature)) return NotFound("температура не может быть ниже -273 по Цельсию");
            var dateTemperature = _weatherForecast.TemperaturesList.FirstOrDefault(item => item.Date == dateTime);
            if (dateTemperature == null)
            {
                return NotFound($"Температура на дату {temperature} не найдена!!!");
            }
            else
            {
                dateTemperature.Temperature = temperature;
                return Ok();
            }
        }

        
        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] DateTime fromDateTime, [FromQuery] DateTime toDateTime)
        {
            _weatherForecast.TemperaturesList.RemoveAll(item => item.Date >= fromDateTime && item.Date <= toDateTime);
            return Ok();
        }


        private static bool Verification(int t) => t < -273;
    }
}