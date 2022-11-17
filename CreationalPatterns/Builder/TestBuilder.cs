using System;

namespace CreationalPatterns.Builder;

public class TestBuilder
{
    public static void run()
    {
        var americanPizzaBuilder = new AmericanPizzaBuilder();
        var waiter = new Waiter(americanPizzaBuilder);
        
        var pizza = waiter.CreatePizza("Spinach+Olives");
        
        Console.WriteLine("Created Pizza: "+ pizza);
    }
}