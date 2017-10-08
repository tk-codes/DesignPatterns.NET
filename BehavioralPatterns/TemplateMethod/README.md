# Template Method

Define the **skeleton of an algorithm in an operation**, deferring some steps to subclasses. Template Method lets **subclasses redefine certain steps of an algorithm** without changing the algorithm's structure.

## Problem

* The invariant parts of a behavior should be implemented only once so that subclasses can implement the variant parts.
* Subclasses should redefine only certain parts of a behavior without changing the other parts.

Usually, subclasses control how the behavior of a parent class is redefined, and they aren't restricted to redefine only certain parts of a behavior.

## Solution

* Define abstract operations (primitives) for the variant parts of a behavior.
* Define a **template method** that
  * implements the invariant parts of a behavior.
  * calls abstract operations (primitives) that subclasses implement.

The **template method** controls how subclasses redefine a behavior. This is also referred to as *inversion of control* because subclasses do no longer control how the behavior of a parent class redefined.

**Definition**

![Template Method Example](/Diagrams/TemplateMethod.png)

```cs
public abstract class CaffeineBeverage
    {

        // Template Method
        // It serves as a template for an algorithm.
        // In this case, an algorithm for making caffeinated beverages.
        public void PrepareRecipe()
        {
            BoilWater();
            Brew(); // abstract -> handled by subclass
            PourInCup();
            AddCondiments(); // abstract --> handled by subclass
        }

        public abstract void Brew();
        public abstract void AddCondiments();

        public void BoilWater()
        {
            Console.WriteLine("Boiling water");
        }

        public void PourInCup()
        {
            Console.WriteLine("Pouring in a cup");
        }
    }
```

**Usage**
```cs
public class Tea : CaffeineBeverage
    {
        public override void Brew()
        {
           Console.WriteLine("Steeping the tea");
        }

        public override void AddCondiments()
        {
            Console.WriteLine("Adding Lemon");
        }
    }
```

```cs
    public class Coffee : CaffeineBeverage
    {
        public override void Brew()
        {
            Console.WriteLine("Dripping Coffee through filter");
        }

        public override void AddCondiments()
        {
            Console.WriteLine("Adding Sugar and Milk");
        }
    }
```

## Common Structure

![Common structure of template method pattern](https://en.wikipedia.org/wiki/Template_method_pattern#/media/File:W3sDesign_Template_Method_Design_Pattern_UML.jpg)

* AbstractClass (DataObject)
  * defines abstract primitive operations that concrete subclasses define to implement steps of an algorithm
  * implements a template method defining the skeleton of an algorithm. The template method calls primitive operations as well as operations defined in AbstractClass or those of other objects.
* ConcreteClass (CustomerDataObject)
  * implements the primitive operations ot carry out subclass-specific steps of the algorithm

_[Source: http://www.dofactory.com/net/template-method-design-pattern]_
