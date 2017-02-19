using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPatterns.Observer
{
    public interface IObservable<T>
    {
        void addObserver(IObserver<T> observer);
        void removeObserver(IObserver<T> observer);
        void notifyObservers();
    }

    public class WeatherData : IObservable<WeatherData>
    {
        private List<IObserver<WeatherData>> observers;
        private float temperature;

        public float Temperature
        {
            get { return this.temperature; }
            set { this.temperature = value; this.notifyObservers(); }
        }

        public WeatherData(float temperature)
        {
            observers = new List<IObserver<WeatherData>>();
            this.Temperature = temperature;
        }

        public void addObserver(IObserver<WeatherData> observer)
        {
            if (!this.observers.Contains(observer))
            {
                this.observers.Add(observer);
            }
        }

        public void removeObserver(IObserver<WeatherData> observer)
        {
            this.observers.Remove(observer);
        }

        public void notifyObservers()
        {
            observers.ForEach(observer => observer.Update(this));
        }
    }
}
