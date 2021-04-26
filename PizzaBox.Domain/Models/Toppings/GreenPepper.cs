using PizzaBox.Domain.Models.Components;

namespace PizzaBox.Domain.Models.Toppings
{
    public class GreenPepper : ATopping
    {
        public GreenPepper()
        {
            Name = "Green Pepper";
            Price = 0.25m;
            TOPPING = TOPPINGS.GREENPEPPER;
        }
    }
}