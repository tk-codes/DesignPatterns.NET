# Iterator Pattern

Provide a way to access the elements of an aggregate object / collection (e.g. trees, graphs and other complex data structures) sequentially without exposing its underlying representation.

## Problem

* The elements of an aggregate object should be accessed and traversed without exposing its representation (data structures).
  * Implementing the access and traversal operations directly in the aggregate interface is inflexible.
* New traversal operations should be defined for an aggregate object without changing its interface.

## Solution

Define a separate `Iterator` object that encapsulates accessing and traversing an aggregate object

## Common Structure

![Common structure of Iterator pattern](img/structure.jpg)

* Iterator
  * defines an interface for accessing and traversing elements
* ConcreteIterator
  * implements the Iterator interface
  * keeps track of the current position in the traversal of the aggregate.
* Aggregate
  * defines an interface for creating an Iterator object
* ConcreteAggregate
  * implements the Iterator creation interface to return an instance of the proper ConcreteIterator.

## Collaboration

* A ConcreteIterator keeps track of the current object in the aggregate and can compute the succeeding object in the traversal.

## Benefits

* Simplifies the code of the aggregate object / collection.
* Provide multiple ways to traverse the same data structure
  * Complex aggregates may be traversed in many ways (e.g. preorder, inorder or postorder traversal of trees)
* Allows parallel traversing of the same collection

## Drawbacks

* Can be overkill for programs that work with simple collections.

## Example

**Definition**

**Usage**

## Comparison with other patterns

* **Composite** - Iterators can be used for traversing Composite trees.
* **Visitor** can be used along with Iterator pattern to traverse a complex data structure and execute some operation over all its elements even if they have different types.
* **Memento** - can be used to capture current iteration state and roll it back if necessary.