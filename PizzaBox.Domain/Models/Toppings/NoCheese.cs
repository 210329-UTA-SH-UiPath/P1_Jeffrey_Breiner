using PizzaBox.Domain.Models.Components;

namespace PizzaBox.Domain.Models.Toppings
{
    public class NoCheese : ATopping
    {
        public NoCheese()
        {
            Name = "No Cheese";
            Price = -0.5m;
            TOPPING = TOPPINGS.NOCHEESE;
        }
    }
}