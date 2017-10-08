# Strategy

The Strategy Pattern 
* defines a family of algorithms, 
* encapsulates each one, and 
* make them interchangeable. 
Strategy lets the algorithm vary independently from clients that use it.

![Duck App with Strategy Pattern](/Diagrams/Strategy.png)

**Usage**
```cs
Duck mallard = new MallardDuck();
mallard.PerformQuack();
mallard.PerformFly();

// change the flying behavior dynamically
Duck model = new ModelDuck();
model.PerformFly(); // default behavior
model.FlyBehavior = new FlyRocketPowered();  // set a different flying behavior at runtime
model.PerformFly();
```


## Common Structure

![Common structure of strategy pattern](http://www.dofactory.com/images/diagrams/net/strategy.gif)

* Strategy  (SortStrategy)
  * declares an interface common to all supported algorithms. Context uses this interface to call the algorithm defined by a ConcreteStrategy
* ConcreteStrategy  (QuickSort, ShellSort, MergeSort)
  * implements the algorithm using the Strategy interface
* Context  (SortedList)
  * is configured with a ConcreteStrategy object
  * maintains a reference to a Strategy object
  * may define an interface that lets Strategy access its data.

_[Source: http://www.dofactory.com/net/strategy-design-pattern]_
