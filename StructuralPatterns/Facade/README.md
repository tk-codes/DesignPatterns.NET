# Facade

Provide a **unifed interface to a set of interfaces in a subsystem**. Facade defines a higher-level interface that makes the subsystem easier to use.

## Problem

* To make a complex subsystem easier to use, a simpler interface should be provided for a set of interfaces in the subsystems.
* The dependencies on a subsystem should be minimized.

## Solution

Define a `Facade` object that
* implements a simple interface which delegates the requests to the interfaces in the subsystem
* may perform additional functionality before/after forwarding a request.

## Common Structure

![Common structure of facade pattern](https://upload.wikimedia.org/wikipedia/commons/9/96/W3sDesign_Facade_Design_Pattern_UML.jpg)

* Facade
  * knows which subsystem classes are responsible for a request.
  * delegates client requests to appropriate subsystem objects.
* Subsystem classes
  * implement subsystem functionality.
  * handle work assigned by the Facade object
  * have no knowledge of the facade and keep no reference to it.

## Collaboration

* Clients communicate with the subsystem by sending requests to Facade.
  * Although the subsystem object perform the actual work, the facade may have to do work of its own to translate its interface to subsystem interfaces.

## Benefits

* A facade not only simplifies an interface, it decouples a client from a subsystem of components.
* Facades help layer a system.

## Drawbacks

* Duplicated methods
* Lower visibility of subsystem functionality.
* It leads to a larger API to maintain.

## Example

TODO

## Relations with Other Patterns

- **Abstract Factory** can be used with Facade to provide an interface for creating subsystem objects in a subsystem-independent way. Abstract Factory can also be used as an alternative to Facade to hide platform-specific classes.
- **Mediator** is similar to Facade in that it abstracts functionality of existing classes. However, Mediator's purpose is to abstract arbitrary communication between colleague objects, often centralizing functionality that doesn't belong in any one of them. A mediator's colleagues are aware of and communicate with the mediator instead of communicating with each other directly. In contrast, a facade merely abstracts the interface to subsystem objects to make them easier to use; it doesn't define new functionality, and subsystem classes don't know about it.
- **Singleton** - Usually only one Facade object is required. Thus Facade objects are often Singletons.