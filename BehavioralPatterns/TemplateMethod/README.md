# Template Method

Define the **skeleton of an algorithm in an operation**, deferring some steps to subclasses. Template Method lets **subclasses redefine certain steps of an algorithm** without changing the algorithm's structure.

## Problem

* The invariant parts of a behavior should be implemented only once so that subclasses can implement the variant parts.
* Subclasses should redefine only certain parts of a behavior without changing the other parts.

Usually, subclasses control how the behavior of a parent class is redefined, and they aren't restricted to redefine only certain parts of a behavior.

## Solution

The Template Method pattern suggests to break down an alogirthm into a series of methods and call them one by one inside a single `template` method.

* Define abstract operations (primitives) for the variant parts of a behavior.
* Define a **template method** that
  * implements the invariant parts of a behavior.
  * calls abstract operations (primitives) that subclasses implement.

The **template method** controls how subclasses redefine a behavior. This is also referred to as *inversion of control* because subclasses do no longer control how the behavior of a parent class redefined.

## Common Structure

![Common structure of template method pattern](https://upload.wikimedia.org/wikipedia/commons/2/2a/W3sDesign_Template_Method_Design_Pattern_UML.jpg)

* AbstractClass (CaffeineBeverage)
  * defines abstract primitive operations that concrete subclasses define to implement steps of an algorithm
  * implements a template method defining the skeleton of an algorithm. The template method calls primitive operations as well as operations defined in AbstractClass or those of other objects.
* ConcreteClass (Tea, Coffee)
  * implements the primitive operations ot carry out subclass-specific steps of the algorithm

## Collaborations

* ConcreteClass relies on AbstractClass to implement the invariant steps of the algorithm.

## Benefits

* Helps to eliminate code duplication

## Drawbacks

* You are limited with a skeleton of an existing algorithm
* Template methods tend to be harder to maintain the more steps they have.

## Known uses

* When subclasses should be able to extend the base algorithm without altering its structure.
* When you have several classes that do similar things with only minor differences. When you alter one of the classes, you have to change others as well (e.g. HTML/PDF/CSV Generator follows the same data processing steps before generating the specific file format).

## Example

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

## Comparison with other patterns

* **Factory Method** are often called by TemplateMethod.

* **Strategy** - Template methods use inheritance to vary part of an algorithm. Strategies use delegation to vary the entire algorithm.