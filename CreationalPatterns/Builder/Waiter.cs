namespace CreationalPatterns.Builder;

// Director
public class Waiter
{
    private PizzaBuilder _pizzaBuilder;

    public Waiter(PizzaBuilder pizzaBuilder)
    {
        _pizzaBuilder = pizzaBuilder;
    }

    public Pizza CreatePizza(string topping)
    {
        _pizzaBuilder.BuildDough();
        _pizzaBuilder.BuildSauce();
        _pizzaBuilder.BuildTopping(topping);
        return _pizzaBuilder.Build();
    }
}