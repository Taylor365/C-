using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAppObserver
{
    public class WeatherData : ISubject
    {
        private List<IObserver> observers = new List<IObserver>();
        private float pressure;
        private float temp;
        private float humidity;

        public void measurementsChanged()
        {            
            notifyObervers();
        }

        public void setMeasurements(float temp, float humidity, float pressure)
        {
            this.temp = temp;
            this.humidity = humidity;
            this.pressure = pressure;
            measurementsChanged();
        }

        public float getPressure()
        {
            return pressure;
        }

        private float getHumidity()
        {
            return humidity;
        }

        private float getTemperature()
        {
            return temp;
        }

        public void registerObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void removeObserver(IObserver o)
        {
            int i = observers.IndexOf(o);
            if (i >= 0)
            {
                observers.Remove(o);
            }            
        }

        public void notifyObervers()
        {
            foreach (IObserver observer in observers)
            {
                observer.update(temp, humidity, pressure);
            }
        }
    }
}
