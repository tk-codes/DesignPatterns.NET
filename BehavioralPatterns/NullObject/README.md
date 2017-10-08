# Null Object

The intent of a **Null Object** is to encapsulate the absense of an object by providing a substitutable alternative that offers suitable default *do nothing* behavior.

## Problem

* An object reference may be optionally null **and**
* This reference must be checked before every use **and**
* The result of a null check is to do nothing or assign a suitable default value.

```cs
if (log != null) {
        log.Write(request);
}

// more statements

if (log != null) {
        log.Write(request);
}
```

## Solution

* Provide a class derived from the object reference's type **and**
* Implement all its methods to do nothing or provide default results **and**
* Use an instance of this class whenever the object reference would have been null

**Definition**
```cs
    interface ILog
    {
        void Write(string message);
    }

    class NullLog : ILog
    {
        public void Write(string message)
        {
            // do nothing
        }
    }
```

![Null Object](/Diagrams/NullObject.png)

**Usage**
```cs
ILog log = new NullLog();

// somewhere later
log.Write(request);
```

## C# Null Propagation
```cs
log?.Write(request);
```