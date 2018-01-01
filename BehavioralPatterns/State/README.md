# State Pattern

Allow an object to alter its behavior when its internal state changes. The object will appear to change its class.

## Problem

- An object should change its behavior when its internal state changes.
- State-specific behavior should be defined independently.
  - New states should be added
  - the behavior of existing states should be changed independently

## Solution

- Define separate State objects that encapsulate state-specific behavior for each state.
- A class delegates state-specific behavior to its current state object instead of implementing state-specific behavior directly.

## Common Structure

![Common structure of State pattern](img/structure.jpg)

* Context
  * maintains an instance of ConcreteState that defines the current state.
* State
  * defines an interface for encapsulating the behavior associated with a particular state of the Context.
* ConcreteState
  * each subclass implements a behavior associated with a state of the Context.

## Collaboration

* Context delegates state-specific requests to the current ConcreteState object.
* A context may pass itself as an argument to the State object handling the request. This lets the State object access the context if necessary.
* Context is the primary interface for clients. Clients can configure a context with State objects. Once a context is configured, its clients don't have to deal with the State objects directly.
* Either Context or the ConcreteState subclasses can decide which state succeeds another and under what circumstances.

## Benefits

* Organizes the code related to particular states into separate classes.
* It makes state transitions explicit by using separate objects for different states.
* Simplifies the code of the context
* State objects can be shared, if they have no instance variables (cf. Flyweight with no intrinsic state but only behavior)

## Drawbacks

* Can be overkill if a state machine has only a few states or rarely changes.

## Example

**Definition**

**Usage**

## Comparison with other patterns

* **Flyweight** pattern explains when and how State objects can be shared.