# Design Principles

* Identify the aspects of your application that vary and separate them from what stays the same.

* Program to an interface, not an implementation.

* Favor composition over inheritance.

* Designs should be open for extension but closed for modification.

* _Dependency Inversion Principle_: Depend upon abstractions. Do not depend upon concrete classes.
** No variable should hold a reference to a concrete class. (eg. using _new_.) --> Use a factory to get around that.
** No class should derive from a concrete class. --> Derive from an interface or an abstract class
** No method should override an implemented method of any of its base classes.

