# Bridge

**Bridge** pattern lets you split a big class into two separate hierachies, abstraction and implementation so that the two can vary independently.

## Problem

* An abstraction and its implementation should be defined and extended independently from each other.
* A compile-time binding between an abstraction and its implementation should be avoided so that an implementation can be selected at run-time.

When using subclassing, different subclasses implement an abstract class in different ways (eg. `Shape <- Sqaure <- BlueSquare/RedSquare`). But an implementation is bound to the abstraction at compile-time and can't be changed at run-time.

![Problem - Bridge Pattern](https://refactoring.guru/images/patterns/diagrams/bridge/problem.png)
*Source: Refactoring.guru*

## Solution

The Bridge pattern attempts to solve it by replacing inheritance with delegations. 

* Separate an abstraction from its implementation by putting them in separate class hierarchies.
* Implement the abstraction in terms of (by delegating to) an `Implementor` object.

This enables to configure an `Abstraction`(Interface) with an `Implementor`(Interface) object at run-time.

![Solution - Bridge Pattern](https://refactoring.guru/images/patterns/diagrams/bridge/solution.png)

## Benefits


## Drawbacks


## Common Structure

![Common structure of bridge pattern](https://upload.wikimedia.org/wikipedia/commons/c/cf/Bridge_UML_class_diagram.svg)

* Abstraction
  * defines the abstraction's interface
  * maintains a reference to an object of type `Implementor`.
* RefinedAbstraction
  * extends the interface defined by `Abstraction`.
* Implementor
  * defines the interface for implementation class. This interface doesn't have to correspond exactly to the `Abstraction`'s interface. Typically the implementation interface provides only primitive operations, and Abstraction defines higher-level operations based on these primitives.
* ConcreteImplementor
  * implements the `Implementor` interface.

_[Source: http://www.dofactory.com/net/memento-design-pattern]_

## Example

