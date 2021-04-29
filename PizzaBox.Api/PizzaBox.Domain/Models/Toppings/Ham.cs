using PizzaBox.Domain.Models.Components;

namespace PizzaBox.Domain.Models.Toppings
{
    public class Ham : ATopping
    {
        public Ham()
        {
            Name = "Ham";
            Price = 0.5m;
            TOPPING = TOPPINGS.HAM;
        }
    }
}