# Observer Pattern

The Observer Pattern defines a one-to-many dependency between objects so that when one object changes state, all of its dependents are notified and updated automatically.

## Problem

* A one-to-many dependency between objects should be defined without making the objects tightly coupled.
* It should be ensured that when one object changes state an open-ended number of dependent objects are updated automatically.
* It should be possible that one object can notify an open-ended number of other objects.

## Solution

* Define `Subject` and `Observer` Objects
* When a subject changes state, all registered observers are notified and updated automatically.

## Common Structure

![Observer Pattern](img/structure.jpg)

- Subject (IObservable)
  - provides an interface for attaching and detaching Observer objects.
- ConcreteSubject  (WeatherData)
  - knows its observers.
  - sends a notification to its observers when its state changes
- Observer  (IObserver)
  - defines an updating interface for objects that should be notified of changes in a subject.
- ConcreteObserver  (CurrentConditionDisplay)
  - maintains a reference to a ConcreteSubject object
  - implements the Observer updating interface to keep its state consistent with the subject's.

  ## Collaboration

- ConcreteSubject notifies its observers whenever a change occurs.
- After being notified, a ConcreteObserver object may query the subject for information.
- The Observer object that initiates the change request **postpone its update**  until it gets a notification from the subject to avoid redundant updates.
* Notify can be called by Subject, Observer or by any other object.

## Benefits

* Abstract coupling between Subject and Observer.
  * Subject is not coupled to concrete classes. All a subject knows is that it has a list of observers, each conforming to abstract `Observer` interface.
* Observers can be attached and detached dynamically.
* Support for broadcast communication
  * The subject doesn't care how many interested objects exist. The notification is broadcast automatically to all of them. It's up to the observer to handle or ignore a notification.

## Drawbacks

* Observers are notified in random order.
* Unexpected updates
  * A seemingly innocuous operation on the subject may cause a cascade of updates to observers and their dependent objects.
  * If dependency criteria aren't well-defined or maintained, it can lead to spurious updates, which can be hard to track down.

## Example

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

## Relations with Other Patterns

- **Mediator** - By encapsulating complex update semantics, the ChangeManager acts as mediator between subjects and observers.
- **Singleton**: The ChangeManager may use the Singleton pattern to make it unique and globally accessible.