# Factory Method

The Factory Method Pattern defines an interface for creating an object, but lets subclasses decide which class to instantiate.

A factory method
* handles object creation and
* encapsulates it in a subclass.

**Definition**
```cs
        // A facotry method
        //    1. is abstract so the subclass are counted on to handle object creation.
        //    2. returns a Product.
        //    3. isolates the client from knowing what of concrete Product is actually created.
        //    4. may be parameterized (or not) to select among several variations of a product.
        protected abstract Pizza CreatePizza(PizzaType type);
```

![Pizza Store with Factory Method](/Diagrams/FactoryMethod.png)

**Definition**
```cs
            PizzaStore americanStore = new AmericanPizzaStore();
            Pizza pizza = americanStore.OrderPizza(PizzaType.Veggie);
            Console.WriteLine("Esposito ordered a " + pizza.Name);
            
            // Italian Pizza Store
            PizzaStore italianStore = new ItalianPizzaStore();
            Pizza pizza = italianStore.OrderPizza(PizzaType.Cheese);
            Console.WriteLine("Esposito ordered a " + pizza.Name);
```

## Common Structure

![Common structure of factory method pattern](http://www.dofactory.com/images/diagrams/net/factory.gif)

* Product (Pizza)
 * defines the interface of objects the factory method creates
* ConcreteProduct (ItalianCheesePizza, AmericanCheesePizza etc.)
 * implements the Product interface
* Creator  (PizzaStore)
 * declares the abstract factory method which returns an instance of type Product.
 * may call the factory method to return an instance (OrderPizza calls CreatePizza)
* ConcreteCreator(AmericanPizzaStore)
 * overrides the abstract factory method to return an instance of a ConcreteProduct (eg. AmericanCheesePizza)

_[Source: http://www.dofactory.com/net/factory-method-design-pattern]_
