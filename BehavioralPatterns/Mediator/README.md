# Mediator

Use the Mediator Pattern to centralize complex communications and control between related objects.

## Problem

* Tight coupling between a set of interacting objects should be avoided.
* It should be possible to change the interaction between a set of objects independently.

*Tightly coupled objects* are hard to implement, change, test and reuse.

## Solution

* Define a `Mediator` object that encapsulates the interaction between a set of objects.
* Objects delegate their interaction to a mediator object instead of interacting with each other directly.

This makes the objects *loosely coupled*.

The Mediator is commonly used to coordinate related GUI components.

## Benefits

* Colleagues classes may become more reusable and are decoupled from the system.
* Simplifies maintenance of the system by centralizing control logic.
* Simplifies and reduces the variety of messages sent between objects in the system.

## Drawbacks

* Without proper design, the mediator object can become overly complex.
* Single point of failure
* Hard to test --> Objects should be mocked

## Example

![Mediator Pattern](/Diagrams/Mediator.png)

Mediator
```cs
 public interface IChatRoom
{
	void RegisterParticipant(IParticipant participant);
	void Send(String from, String to, string message);
}
```

ConcreteMediator
```cs
public class ChatRoom : IChatRoom
{
	private readonly IDictionary<string, IParticipant> _participants = new Dictionary<string, IParticipant>();

	public void RegisterParticipant(IParticipant participant)
	{
		this._participants.Add(participant.GetName(), participant);
	}

	public void Send(string from, string to, string message)
	{
		if (this._participants.ContainsKey(to))
		{
			this._participants[to].Receive(from, message);
		}
		else
		{
			throw new ArgumentException("{0} not found", to);
		}
	}
}
```

Colleague
```cs
public interface IParticipant
{
	string GetName();
	void Send(string to, string message);
	void Receive(string from, string message);
}
```

ConcreteColleague
```cs
public class Participant : IParticipant
{
	private readonly string _name;
	private readonly IChatRoom _chatRoom;

	public Participant(string name, IChatRoom chatRoom)
	{
		this._name = name;
		this._chatRoom = chatRoom;

		this._chatRoom.RegisterParticipant(this);
	}
	public string GetName()
	{
		return this._name;
	}

	public void Send(string to, string message)
	{
		this._chatRoom.Send(this._name, to, message);
	}

	public void Receive(string from, string message)
	{
		Console.WriteLine("{0} to {1}: {2}", from, this._name, message);
	}
}
```

Usage
```cs
IChatRoom chatRoom = new ChatRoom();

IParticipant einstein = new Participant("Einstein", chatRoom);
IParticipant newton = new Participant("Newton", chatRoom);
IParticipant galileo = new Participant("Galileo", chatRoom);

newton.Send(galileo.GetName(), "I discoverd laws of motion");
einstein.Send(newton.GetName(), "I discovered how gravity works");
```

## Common Structure

![Common structure of mediator pattern](https://upload.wikimedia.org/wikipedia/commons/9/92/W3sDesign_Mediator_Design_Pattern_UML.jpg)

* Mediator (IChatRoom)
  * defines an interface for communicating with Colleague objects
* ConcreteMediator (ChatRoom)
  * implements cooperative behavior by coordinating Colleague objects.
  * knows and maintains its colleagues.
* Colleague (IParticipant)
  * defines an interface for using Colleague objects.
* ConcreateColleague (Participant)
  * each colleague knows its Mediator object
  * each colleague communicates with its mediator whenever it would have otherwise communicated with another colleague.

_[Source: http://www.dofactory.com/net/mediator-design-patternttp://www.dofactory.com/net/adapter-design-pattern]_