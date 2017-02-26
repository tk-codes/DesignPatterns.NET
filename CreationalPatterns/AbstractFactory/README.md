# Abstract Factory

The Abstract Factory Pattern provides an interface for creating families of related or dependent objects without specifying their concrete classes.

**Definition** - AbstractFactory and ConcreteFactory
```cs
    public interface PizzaIngredientFactory
    {
        Dough CreateDough();
    }

    public class AmericanPizzaIngredientFactory : PizzaIngredientFactory
    {
        public Dough CreateDough()
        {
            return new ThickCrustDough();
        }
    }

    public class ItalianPizzaIngredientFactory : PizzaIngredientFactory
    {
        public Dough CreateDough()
        {
            return new ThinCrustDough();
        }
    }
```

**Definition** - AbstractProduct and ConcreteProduct
```cs
    public interface Dough
    {
        string GetName();
    }

    public class ThickCrustDough : Dough
    {
        public string GetName()
        {
            return "Extra thick crust dough";
        }
    }

    public class ThinCrustDough : Dough
    {
        public string GetName()
        {
            return "Thin crust dough";
        }
    }
```

![Pizza Store with Factory Method](../../Diagrams/AbstractFactory.png)

**Usage**
```cs
    public class AmericanPizzaStore : PizzaStore
    {
        // AmericanPizzaStore creates the corresponding ingriedient factory.
        private PizzaIngredientFactory ingredientFactory = new AmericanPizzaIngredientFactory();

        protected override Pizza CreatePizza(PizzaType type)
        {
            switch (type)
            {
                case PizzaType.Cheese:
                    // the correct ingredientFactory is transferred when creating a pizza
                    return new CheesePizza(ingredientFactory);
                case PizzaType.Veggie:
                    return new VeggiePizza(ingredientFactory);
                default:
                    throw new NotImplementedException();
            }
        }
    }
```

## Common Structure

![Common structure of abstract factoring pattern](https://upload.wikimedia.org/wikipedia/commons/thumb/9/9d/Abstract_factory_UML.svg/677px-Abstract_factory_UML.svg.png)

* AbstractFactory (PizzaIngredientFactory)
 * declares an interface for operations that create abstract products
* ConcreteFactory (ItalianPizzaIngredientFactory, AmericanPizzaIngredientFactory)
 * implements the operations to create concrete product objects
* AbstractProduct  (Dough)
 * declares an interface for a type of product object
* ConcreteProduct(ThinCrustDough, ThickCrustDough)
 * defines a product object to be created by the corresponding concrete factory
 * implements the AbstractProduct interface

_[Source: http://www.dofactory.com/net/abstract-factory-design-pattern]_
