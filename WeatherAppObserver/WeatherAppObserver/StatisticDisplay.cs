using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAppObserver
{
    public class StatisticDisplay : IObserver, IDisplayElement
    {
        private float maxTemp = 0.0f;
        private float minTemp = 200;
        private float tempSum = 0.0f;
        private int numReadings;
        private WeatherData weatherData;

        public StatisticDisplay(WeatherData weatherData)
        {
            this.weatherData = weatherData;
            weatherData.registerObserver(this);
        }

        public void update(float temp, float humidity, float pressure)
        {
            tempSum += temp;
            numReadings++;

            if (temp > maxTemp)
            {
                maxTemp = temp;
            }

            if (temp < minTemp)
            {
                minTemp = temp;
            }

            display();
        }

        public void display()
        {
            Console.WriteLine("Avg/Max/Min temperature = " + (tempSum / numReadings)
                + "/" + maxTemp + "/" + minTemp);
        }
    }
}
