namespace CreationalPatterns.Builder;

public class AmericanPizzaBuilder : PizzaBuilder
{
    public override void BuildDough()
    {
        Pizza.Dough = "pan baked";
    }

    public override void BuildSauce()
    {
        Pizza.Sauce = "hot spicy";
    }

    public override void BuildTopping(string topping = "")
    {
        Pizza.Topping = topping;
    }
}