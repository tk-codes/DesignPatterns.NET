# Strategy

The Strategy Pattern 
* defines a family of algorithms, 
* encapsulates each one, and 
* make them interchangeable. 

Strategy lets the algorithm vary independently from clients that use it.

## Problem

- A class should be configured with an algorithm instead of implementing an algorithm directly.
- An algorithm should be selected and exchanged at run-time.

## Solution

- Define an interface `Strategy` for performing an algorithm and define separate classes that implement the `Strategy` interface and encapsulate an algorithm in different ways.

## Common Structure

![Common structure of strategy pattern](img/structure.jpg)

* Strategy  (SortStrategy)
  * declares an interface common to all supported algorithms. Context uses this interface to call the algorithm defined by a ConcreteStrategy
* ConcreteStrategy  (QuickSort, ShellSort, MergeSort)
  * implements the algorithm using the Strategy interface
* Context  (SortedList)
  * is configured with a ConcreteStrategy object
  * maintains a reference to a Strategy object
  * may define an interface that lets Strategy access its data.

## Collaboration

- A context may pass all data required by the algorithm to the strategy when an algorithm is called.
- A context forwards requests from its clients to its strategy. Clients usually create and pass a ConcreteStrategy object to the context; thereafter clients interact with the context exclusively.

## Benefits

* Families of related algorithms
  * Inheritance can help factor out common functionality of the algorithm
* Lets you vary the algorithm independently of its context, making it easier to understand, extend and switch algorithms at run-time.
* Eliminate conditional statements for selecting desired behavior.

## Drawbacks

* Increases overall code complexity by creating multiple additional classes.
* Client must be aware of the differences between strategies to pick a proper one.

## Example

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

## Relations with Other Patterns

- **Flyweight** - Strategy objects often make good flyweights.
