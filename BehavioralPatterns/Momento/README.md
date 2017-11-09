# Memento

The Memento pattern provides the abilitiy to restore an object to its previous state later.

## Problem

* The internal state of an object should be saved externally so that the object can be restored to this state later.
* The object's encapsulation must not be violated.

## Solution

Make an object (originator) itself responsible for
* saving its internal state to a `memento` object and
* restoring to a previous state from a `memento` object.

Only the originator that created a memento is allowed to access it.

A client (caretaker) can request a memento from the originator to save the internal state. It can also pass a memento back to the originator to restore to a previous state.

## Benefits

* Does not violate the originator's encapsulation.
* Keeping the saved state external from the originator helps to maintain cohesion.
* Provides easy-to-implement recovery capability.

## Drawbacks

* Saving and restoring state can be time consuming.
* It may require lots of memory if clients create mementors too often.
* Clients should track the originator's lifecycle in order to destroy obsolete mementos.

## Common Structure

![Common structure of memento pattern](https://upload.wikimedia.org/wikipedia/commons/3/38/W3sDesign_Memento_Design_Pattern_UML.jpg)

* Memento
  * is a value object that stores internal state of the Originator object.
  * It is common practice to make Memento immutable and pass it data only once, via constructor.
* Originator
  * creates a memento containing a snapshot of its current internal state.
  * uses the memento to restore its internal state
* Caretaker
  * keeps a history of originator's state by storing a stack of mementos
  * never operates on or examines the contents of a memento
  * When originator has to go back in history, the caretaker passes the last memento to the originator's restoration method.

_[Source: http://www.dofactory.com/net/memento-design-pattern]_

## Example

Memento
```cs
[Serializable]
class Memento
{
	public string State { get; }

	public Memento(String state)
	{
		this.State = state;
	}
}
```

Originator
```cs
class Originator
{
	private String _state;

	public void SetState(String state)
	{
		this._state = state;
		Console.WriteLine($"State is set to {state}");
	}

	public Memento Save()
	{
		Console.WriteLine($"Saving state to Memento");
		return new Memento(this._state);
	}

	public void Restore(Memento m)
	{
		this._state = m.State;
		Console.WriteLine($"State is restored from Memento: {_state}");
	}
}
```

CareTaker
```cs
IList<Memento> mementoes = new List<Memento>();

Originator originator = new Originator();
originator.SetState("State 1");
originator.SetState("State 2");
mementoes.Add(originator.Save()); // checkpoint 1

originator.SetState("State 3");
mementoes.Add(originator.Save()); // checkpoint 2

originator.SetState("State 4");
originator.Restore(mementoes[0]); // restore to checkpoint 1
```

Output
```
State is set to State 1
State is set to State 2
Saving state to Memento
State is set to State 3
Saving state to Memento
State is set to State 4
State is restored from Memento: State 2
```