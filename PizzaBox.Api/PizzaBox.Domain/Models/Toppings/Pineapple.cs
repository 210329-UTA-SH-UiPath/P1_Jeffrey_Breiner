using PizzaBox.Domain.Models.Components;

namespace PizzaBox.Domain.Models.Toppings
{
    public class Pineapple : ATopping
    {
        public Pineapple()
        {
            Name = "Pineapple (the best toping)";
            Price = 0.5m;
            TOPPING = TOPPINGS.PINEAPPLE;
        }
    }
}