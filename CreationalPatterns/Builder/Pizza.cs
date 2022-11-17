namespace CreationalPatterns.Builder;

public class Pizza
{
    public string Dough { get; set; }

    public string Sauce { get; set; }

    public string Topping { get; set; }

    public override string ToString()
    {
        return $"{Dough}+{Sauce}+{Topping}";
    }
}