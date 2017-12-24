# Flyweight

Use sharing to support large numbers of objects efficiently and to save RAM.

## Problem

* Large numbers of objects should be supported efficiently.
* Creating large numbers of objects should be avoided.

When representing large text documents, for example, creating an object for each character in the document would result in a huge amount of objects that couldn't be processed efficiently.

## Solution

Define `Flyweight` objects that

* store intrinsic (invariant) state that can be shared
  * *intrinsic state* is context independent, for example the character `A`.
* provide an interface through which extrinsic (variant) state can be passed in
  * extrinsic state depends on and varies with the flyweight's context and therefore can't be shared, for example the position of the character `A` in a GUI.

This enables clients to reuse / share Flyweight objects (instead of creating a new object each time) and pass in extrinsic state when they invoke a Flyweight operation.
This greatly reduces the number of physically created objects.

## Common Structure

![Common structure of Flyweight pattern](https://upload.wikimedia.org/wikipedia/commons/4/4e/W3sDesign_Flyweight_Design_Pattern_UML.jpg)

* Flyweight
  * declares an interface through which flyweights can receive and act on extrinsic state.
* ConcreteFlyweight
  * implements the Flyweight interface and holds the intrinsic state, which must be independent of the object's context.
* UnsharedConcreteFlyweight (not appropriate)
* FlyweightFactory
  * creates and manages flyweight objects
  * ensures that flyweights are shared properly. When a client requests a flyweight, the FlyweightFactory object supplies an exisiting instance or creates one, if none exists.
* Client
  * maintains a reference to flyweights.
  * computes or stores the extrinsic state of flyweights.

## Collaboration

* Clients should not instantiate ConcreteFlyweights directly. Clients must obtain ConcreteFlyweight objects exclusively from the FlyweightFactory object to ensure they are shared properly.

## Benefits

* Saves RAM, thus allowing a program to support much more objects.

## Drawbacks

* Wastes CPU time on searching or calculating the context
* Increases overall code complexity by creating multiple additional classes.

## Example

**Definition**

**Usage**

## Comparison with other patterns

* **Composite** - Flyweight is often combined with Composite to implement a shared leaf nodes and save RAM. 
  * A consequence of sharing is that flyweight leaf nodes cannot store a pointer to their parent. Rather, the parent pointer is passed to the flyweight as part of its extrinsic state. This has a major impact on how the objects in the hierarchy communicate with eath other.

* It's often best to implement `State` and `Strategy` objects as flyweights.

* Flyweight looks almost like `Singleton`. The key differences are
  1. Singleton object can be mutable. Flyweight objects are immutable.
  2. There should be only one Singleton instance, whereas Flyweight class can have multiple instances with a different intrinsic state.