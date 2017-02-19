# Observer Pattern

The Observer Pattern defines a one-to-many dependency between objects so that when one object changes state, all of its dependents are notified and updated automatically.

**Definition**
```cs
        // Observable / Subject
        public interface IObservable<T>
        {
                void addObserver(IObserver<T> observer);
                void removeObserver(IObserver<T> observer);
                void notifyObservers();
        }

        // Observer
         public interface IObserver<T>
        {
                void Update(T data);
        }
```

![Observer Pattern](/Diagrams/Observer.png)

**Usage**
```cs
        WeatherData data = new WeatherData(13);

        CurrentConditionDisplay display1 = new CurrentConditionDisplay("Display1", data); 
        // OUTPUT --> Display1 - Temperature: 13
        CurrentConditionDisplay display2 = new CurrentConditionDisplay("Display2", data);
        // OUTPUT --> Display2 - Temperature: 13

        // update the temperature.
        data.Temperature = 14;
        
        // Display 1 and 2 show the new temperature
        // OUTPUT: 
        /* Weather data is updated
           Display1 - Temperature: 14
           Weather data is updated
           Display2 - Temperature: 14
        */

        data.removeObserver(display2);
        data.Temperature = 15;

        // Only Display 1 shows the new temperature
        // OUTPUT: 
        /* Weather data is updated
           Display1 - Temperature: 15
        */

        Console.ReadLine();
```

## Common Structure


![Observer Pattern](http://www.dofactory.com/images/diagrams/net/observer.gif)

- Subject (IObservable)
  - provides an interface for attaching and detaching Observer objects.
- ConcreteSubject  (WeatherData)
  - knows its observers.
  - sends a notification to its observers when its state changes
- Observer  (IObserver)
  - defines an updating interface for objects that should be notified of changes in a subject.
- ConcreteObserver  (CurrentConditionDisplay)
  - maintains a reference to a ConcreteSubject object
  - implements the Observer updating interface to keep its state consistent with the subject's

  _[Source: http://www.dofactory.com/net/observer-design-pattern]_

  Checkout built-it Observer Pattern in .NET -  [Observer Design Pattern Best Practices](https://msdn.microsoft.com/en-us/library/ff519622(v=vs.110).aspx)

  # .NET Event

  Define update method as a delegate.
  ```cs
        public delegate void TemperatureChanged(WeatherDataWithEvent weatherData);
  ```

  ConcreateSubject/Observable creates an event with the defined delegate method above.

  ```cs
  public class WeatherDataWithEvent
    {
        private float temperature;

        // declare event OnTemperatureChanged
        public event TemperatureChanged OnTemperatureChanged;

        public float Temperature
        {
            get { return this.temperature; }
            set {
                this.temperature = value;

                // event subscribers will be notified
                OnTemperatureChanged?.Invoke(this);
            }
        }    
    }
    ```

Observers can register themselves as follows
```cs
// Class: CurrentConditionDisplayWithEvent

// subscribe
weatherData.OnTemperatureChanged += this.OnTemperatureChanged;

// unsubscribe
weatherData.OnTemperatureChanged -= this.OnTemperatureChanged;
```