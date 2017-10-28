# Facade

Provide a **unifed interface to a set of interfaces in a subsystem**. Facade defines a higher-level interface that makes the subsystem easier to use.

## Problem

* To make a complex subsystem easier to use, a simpler interface should be provided for a set of interfaces in the subsystems.
* The dependencies on a subsystem should be minimized.

## Solution

Define a `Facade` object that
* implements a simple interface which delegates the requests to the interfaces in the subsystem
* may perform additional functionality before/after forwarding a request.

## Benefits

* A facade not only simplifies an interface, it decouples a client from a subsystem of components.
* Facades help layer a system.

## Drawbacks

* Duplicated methods
* Lower visibility of subsystem functionality.
* It leads to a larger API to maintain.

## Common Structure

![Common structure of facade pattern](https://upload.wikimedia.org/wikipedia/commons/9/96/W3sDesign_Facade_Design_Pattern_UML.jpg)

* Facade
  * knows which subsystem classes are responsible for a request.
  * delegates client requests to appropriate subsystem objects.
* Subsystem classes
  * implement subsystem functionality.
  * handle work assigned by the Facade object
  * have no knowledge of the facade and keep no reference to it.

_[Source: http://www.dofactory.com/net/facade-design-pattern]_