namespace CreationalPatterns.Builder;

public class ItalianPizzaBuilder : PizzaBuilder
{
    public override void BuildDough()
    {
        Pizza.Dough = "crispy thin";
    }

    public override void BuildSauce()
    {
        Pizza.Sauce = "mild";
    }

    public override void BuildTopping(string topping = "")
    {
        Pizza.Topping = topping;
    }
}