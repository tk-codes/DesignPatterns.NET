# Adapter

**Convert the interface of a class into another interface** client expect. Adapter lets classes work together that couldn't otherwise because of incompatible interfaces.

## Problem

* You've got an existing software system. The interface of the new vendor class you need to work with doesn't match with your existing code.
* Changing the existing code is expensive or will affect the other working functionalities.

## Solution

Write a `Adapter` class that adapts the new vendor interface into the one you're expecting. The adapter acts as the middleman by receiving requests from the client and converting them into requests that make sense on the vendor class.

## Benefits

* It allows more flexibility in design
* They handle logic by wrapping a new interface around that of an exisiting class so you can use new APIs and avoid breaking existing implementations.
* It absolutely interconnects two incompatible interfaces.

## Drawbacks

* Sometimes many adaptations are required along an adapter chain to reach the required type.

## Class Adapter (eg. `Stack<E> extends Vector<E>`)

**Benefits**

* Adapts only the required methods of the existing class and leave the others unchanged.
* No additional object is required.

**Drawbacks**

* The whole interface of the existing class is visible
* Not able to adapt all the subclasses of the existing class at one go. You have to define explicitely which (sub-)class you adapt.

## Object Adapter

**Benefits**

* Subclasses of the existing class can also be adapted easily.

**Drawbacks**

* Every required method of the existing class should be redefined in Adapter class. It unnecessarily increases the size of code, because a lot of code is needlessly duplicated.
* Additional object is required.

## Example

Target (Duck)
```cs
// Target
public interface IDuck
{
	void Quack();
	void Fly();
}
```

Adaptee (Turkey)
```cs
public interface ITurkey
{
	// Turckeys don't quack, they gobble
	void Gobble();
	void Fly();
}

public class WildTurkey : ITurkey
{
	public void Gobble()
	{
		Console.WriteLine("Gobble gobble");
	}

	public void Fly()
	{
		Console.WriteLine("Flying short distance");
	}
}
```

Class Adapter
```cs
class TurkeyClassAdapter : WildTurkey, IDuck
{
	public void Quack()
	{
		base.Gobble();
	}

	void IDuck.Fly()
	{
		for (int i = 0; i < 5; i++)
		{
			base.Fly();
		}
	}
}
```

Object Adapter
```cs
public class TurkeyObjectAdapter : IDuck
{
	private readonly ITurkey _turkey;

	public TurkeyObjectAdapter(ITurkey turkey)
	{
		this._turkey = turkey;
	}

	public void Quack()
	{
		_turkey.Gobble();
	}

	public void Fly()
	{
		for (int i = 0; i < 5; i++)
		{
			_turkey.Fly();
		}
	}
}
```

Client
```cs
public static void Run()
{
	// Class Adapter
	TurkeyClassAdapter classAdapter = new TurkeyClassAdapter();
	testDuck(classAdapter);

	// Object Adapter
	WildTurkey turkey = new WildTurkey();
	TurkeyObjectAdapter objectAdapter = new TurkeyObjectAdapter(turkey);
	testDuck(objectAdapter);
}

// Client expects duck interface only
static void testDuck(IDuck duck)
{
	duck.Quack();
	duck.Fly();
}
```

## Common Structure

![Common structure of adapter pattern](https://upload.wikimedia.org/wikipedia/commons/e/e5/W3sDesign_Adapter_Design_Pattern_UML.jpg)

* Target (Duck)
  * defines the domain-specific interface that client uses.
* Adapter (TurkeyClassAdapter, TurkeyObjectAdapter)
  * adapts the interface Adaptee to the Target interface.
* Adaptee (Turkey)
  * defines an existing interface that needs adapting.
* Client
  * collaborates with objects conforming to the Target interface.

_[Source: http://www.dofactory.com/net/adapter-design-pattern]_