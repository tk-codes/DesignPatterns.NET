using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPatterns.Observer
{
    public delegate void TemperatureChanged(WeatherDataWithEvent weatherData);

    public class WeatherDataWithEvent
    {
        private float temperature;
        public event TemperatureChanged OnTemperatureChanged;

        public float Temperature
        {
            get { return this.temperature; }
            set {
                this.temperature = value;
                OnTemperatureChanged?.Invoke(this);
            }
        }

        public WeatherDataWithEvent(float temperature)
        {
            this.Temperature = temperature;
        }       
    }

    class CurrentConditionDisplayWithEvent
    {
        private WeatherDataWithEvent data;
        private string name;

        public CurrentConditionDisplayWithEvent(string name, WeatherDataWithEvent data)
        {
            this.name = name;
            this.data = data;

            this.data.OnTemperatureChanged += this.OnTemperatureChanged;
            Display();
        }

        public void OnTemperatureChanged(WeatherDataWithEvent data)
        {
            Console.WriteLine("Weather data is updated");
            this.data = data;
            Display();
        }

        private void Display()
        {
            Console.WriteLine("{0} - Temperature: {1}", this.name, this.data.Temperature);
        }
    }
}
