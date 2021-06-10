using System;
using System.Collections.Generic;

namespace WeatherForecast
{
    public class WeatherForecast
    {
        public List<DateTemperatures> TemperaturesList { get; set; } = new List<DateTemperatures>();

        
        public WeatherForecast()
        {
            DataGrid();
        }
        

        private void DataGrid()
        {
            for (var j = 0; j < 200; j++)
            {
                var dt = new DateTime(2021, 06, new Random().Next(1, 30), new Random().Next(0,24), new Random().Next(0,60), 00);
                if(!TemperaturesList.Exists((i => i.Date == dt)))
                {
                    TemperaturesList.Add(new DateTemperatures(dt, new Random().Next(0, 50)));
                }
            }
        }
    }
}