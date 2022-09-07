using System;

namespace WeatherForecast
{
    public class DateTemperatures
    {
        public DateTime Date { get; private set; }
        public int Temperature { get; set; }

        
        public DateTemperatures(DateTime date, int temperature)
        {
            Date = date;
            Temperature = temperature;
        }
    }
}