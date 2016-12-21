# Singleton

![ChocolateBoiler as Singleton](/CreationalPatterns/doc/Singleton.png)

## Static Initialization

:thumbsup: **You may want to create your Singleton eagerly**, if
* your application always creates and uses an instance of the `Singleton`
* the overhead of creation and runtime aspects of the Singleton are not onerous

:thumbsdown: **Downside**
* You have less control over the mechanics of the instantiation

[ChocolateBoiler_StaticInit.cs](/CreationalPatterns/Singleton/ChocolateBoiler_StaticInit.cs).
```cs
    public sealed class ChocolateBoiler_StaticInit
    {
        // singleton instance
        private static readonly ChocolateBoiler_StaticInit instance = new ChocolateBoiler_StaticInit();

        public static ChocolateBoiler_StaticInit Instance
        {
            get
            {
                return instance;
            }
        }
    }
```

The class is marked as **sealed** to prevent derivation, which could add instances. In addition, the variable is marked **readonly**, which means that it can be assigned only during static Initialization or in a class constructor.

Because the **Singleton** instance is referenced by a private static member variable, the instantiation does not occur until the class is first referenced by a call to the **Instance** property. This solution therefore implements a form of the lazy instantiation property, as in the Design Patterns form of Singleton.

## Multithreaded Singleton

:thumbsup: **Use double-checked locking**, if
* you want to keep separate threads from creating new instances of the singleton at the same time (thread-safe)
* you want to create an instance only when the instance is needed.

Reference: 
* MSDN - [Implementing Singleton in C#](https://msdn.microsoft.com/en-us/library/ff650316.aspx)
