using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPatterns.Observer
{
    public interface IObserver<T>
    {
        void Update(T data);
    }

    class CurrentConditionDisplay : IObserver<WeatherData>
    {
        private WeatherData data;
        private string name;

        public CurrentConditionDisplay(string name, WeatherData data)
        {
            this.name = name;
            this.data = data;
            data.addObserver(this);
            Display();
        }

        public void Update(WeatherData data)
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
