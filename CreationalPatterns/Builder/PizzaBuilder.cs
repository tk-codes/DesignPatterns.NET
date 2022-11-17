namespace CreationalPatterns.Builder;

public abstract class PizzaBuilder
{
    protected readonly Pizza Pizza;

    public PizzaBuilder()
    {
        Pizza = new Pizza();
    }

    public abstract void BuildDough();
    public abstract void BuildSauce();
    public abstract void BuildTopping(string topping = "");

    public Pizza Build()
    {
        return Pizza;
    }
}