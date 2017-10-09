# Prototype

Prototype pattern refers to creating duplicate object while keeping performance in mind.

## Problem

* Creating an instance is either expensive or complicated

## Solution

* Make new instances by copying existing instances (`clone`)
* De-serialize when you need deep copies

## Benefits

* Hides the complexities of making new instances from the client.
* Provides the option for the client to generate objects whose type is not known.
* In some circumstances, copying an object can be more efficient than creating a new object.

## Drawbacks

* Making a copy of an object can sometimes be complicated and error-prone. 

Questions:
1. Should clonable interface be implemented?
2. What return type (Super class or concrete class) should the clone method have?

**Definition**
```cs
public abstract class Shape
{
    public int Id { get; set; }
    public string Type { get; }

    protected Shape(string type)
    {
        Type = type;
    }

    public abstract Shape Clone();
}
```

```cs
public class Circle : Shape
{

    public Circle() : base("Circle")
    {

    }

    // The MemberwiseClone method creates a shallow copy by creating a new object.
    // Thenand it copies the nonstatic fields of the current object to the new object.
    // If a field is a value type, a bit-by-bit copy of the field is performed. 
    // If a field is a reference type, the reference is copied but the referred object is not.
    // Therefore, the original object and its clone refer to the same object.
    public override Shape Clone()
    {
        return (Shape) this.MemberwiseClone();
    }
}

public class Square : Shape
{

    public Square() : base("Square")
    {

    }

    public override Shape Clone()
    {
        return (Shape) this.MemberwiseClone();
    }
}
```

```cs
class ShapeManager
{
    public static Shape GetShape(string key)
    {
        return Shapes[key].Clone();
    }
}
```
![Prototype](/Diagrams/Prototype.png)

**Usage**
```cs
ShapeManager.LoadShapes();

Shape clonedCircle = ShapeManager.GetShape("Circle");
Console.WriteLine(clonedCircle);

Shape clonedCircle2 = ShapeManager.GetShape("Circle");
Console.WriteLine(clonedCircle2);

Shape cloneSquare = ShapeManager.GetShape("Square");
Console.WriteLine(cloneSquare);
```

Output
```bash
Shape: 1 - Circle@46104728
Shape: 1 - Circle@12289376
Shape: 2 - Square@43495525
```

## Common Structure

![Common structure of prototype pattern](http://www.dofactory.com/images/diagrams/net/prototype.gif)

* Prototype (Shape)
  * declares an interface for cloning itself
* ConcretePrototype (Circle, Square)
  * implements an operation for cloning itself
* Client (ShapeManager)
  * creates a new object by asking a prototype to clone itself.

_[Source: http://www.dofactory.com/net/prototype-design-pattern]_