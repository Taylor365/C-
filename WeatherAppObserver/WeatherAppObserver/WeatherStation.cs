using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAppObserver
{
    public class WeatherStation
    {
        public static void Main(string[] args)
        {
            WeatherData weatherData = new WeatherData();

            CurrentConditionsDisplay currentDisplay = new CurrentConditionsDisplay(weatherData);

            StatisticDisplay staticDisplay = new StatisticDisplay(weatherData);
            ForecastDisplay forecastDisplay = new ForecastDisplay(weatherData);
            HeatIndexDisplay heatIndexDisplay = new HeatIndexDisplay(weatherData);
            weatherData.setMeasurements(80, 64, 30.4f);
            weatherData.setMeasurements(82, 70, 29.2f);
            weatherData.setMeasurements(78, 90, 29.2f);

            Console.ReadLine();
        }
    }
}
