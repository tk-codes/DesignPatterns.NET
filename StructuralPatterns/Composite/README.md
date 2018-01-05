# Composite Pattern

The intent of composite pattern is to *compose* objects into tree structures to represent part-whole hierarchies. Composite lets clients treat individual objects and compositions of objects uniformly.

## Problem

* A part-whole hierarchy should be represented so that clients can treat part and whole objects uniformly.
* A part-whole hierarchy should be represented as tree structure.

## Solution

* Define a unified `Component` interface for both part (`Leaf`) objects and whole (`Composite`) objects.
* Individual `Leaf` objects implement the `Component` interface directly, and `Composite` objects forward requests to their child components.

## Common Structure

![Common structure of composite pattern](https://upload.wikimedia.org/wikipedia/commons/6/65/W3sDesign_Composite_Design_Pattern_UML.jpg)

* Component (IFileSystemComponent)
  * declares an interface for objects in the composition.
  * implements default behaviour for the interface common to all classes, as appropriate.
* Leaf (File)
  * A leaf has no children.
  * defines behavior for primitive objects in the composition.
* Composite (Folder)
  * stores child components
  * defines/implements behaviour for components having children.
* Client (FileSystem)
  * manipulates objects in the composition through the Component interface.

## Collaboration

* Clients use the Component class interface to interact with objects in the composite structure.
    * If the recipient is a Leaf, then the request is handled directly.
    * If the recipient is a Composite, then it usually forwards requests to its child components, possibly performing additional operations before and/or after forwarding.

## Benefits

* Makes the client simple.
  * It can apply the same operations over both composites and individual objects (leaves).
* In most cases we can ignore the differences between the composition of objects and leaves.
* Makes it easier to add new kinds of components
  * Newly defined Composite or Leaf subclasses work automatically with existing structures and client code.

## Drawbacks

* In specific cases, it is difficult to restrict the components of the tree to only particular types. Therefore, to enforce such contraint, the program must rely on run-time checks, since it cannot use the *type system* of programming language.

**Definition**

Component
```cs
 interface IFileSystemComponent
{
   void PrintName(string prefix);
}
```

Leaf
```cs
class File : IFileSystemComponent
{
    public string Name { get; set; }
    public File(string name)
    {
        this.Name = name;
    }

    public void PrintName(string prefix = "")
    {
        Console.WriteLine("{0} {1}", prefix, Name);
    }
}
```

Composite
```cs
class Folder : IFileSystemComponent
{
    private readonly List<IFileSystemComponent> _fsComponents;
    public string Name { get; set; }

    public Folder(string name)
    {
        this.Name = name;
        this._fsComponents = new List<IFileSystemComponent>();
    }

    ...

    public void PrintName(string prefix = "")
    {
        Console.WriteLine("{0} {1}", prefix, Name);
        foreach (var fileSystemComponent in _fsComponents)
        {
            fileSystemComponent.PrintName(prefix + "\t");
        }
    }
}
```
![Prototype](/Diagrams/Composite.png)

**Usage**
```cs
Folder mainFolder = new Folder("Main Folder");
Folder subFolder1 = new Folder("Sub Folder 1");
Folder subFolder2 = new Folder("Sub Folder 2");

mainFolder.Add(subFolder1);
mainFolder.Add(subFolder2);
mainFolder.Add(new File("File 1 in Main Folder"));

subFolder1.Add(new File("File 1 in Sub Folder 1"));
subFolder1.Add(new File("File 2 in Sub Folder 1"));

subFolder2.Add(new File("File 1 in Sub Folder 2"));
subFolder2.Add(new Folder("Empty folder in Sub Folder 2"));

mainFolder.PrintName();
```

Output
```bash
 Main Folder
         Sub Folder 1
                 File 1 in Sub Folder 1
                 File 2 in Sub Folder 1
         Sub Folder 2
                 File 1 in Sub Folder 2
                 Empty folder in Sub Folder 2
         File 1 in Main Folder
```

## Relations with Other Patterns

* **Chain of Responsibility** - Often the component-parent link is used for a Chain of Responsibility.
* **Decorator** is often used with Composite. When decorators and composites are used together, they will usually have a common parent class. So decorators will have to support the Component interface with operations like Add, Remove, and GetChild.
* **Flyweight** lets you share components, but they can no longer refer to their parents.
* **Iterator** can be used to traverse composites.
* **Visitor** localizes operations and behavior that would otherwise be distributed across Composite and Leaf classes.