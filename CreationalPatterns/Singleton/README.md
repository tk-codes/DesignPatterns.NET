# Singleton

![ChocolateBoiler as Singleton](/CreationalPatterns/doc/Singleton.png)

## Static Initialization

If your applicatioin always creates and uses an instance of the `Singleton` or the overhead of creation and runtime aspects of the Singleton are not onerous, you may want to create your Singleton eagerly, like `ChocolateBoiler_StaticInit.cs`.

The class is marked as **sealed** to prevent derivation, which could add instances. In addition, the variable is marked **readonly**, which means that it can be assigned only during static Initialization or in a class constructor.

