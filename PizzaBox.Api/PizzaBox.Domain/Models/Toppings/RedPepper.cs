using PizzaBox.Domain.Models.Components;

namespace PizzaBox.Domain.Models.Toppings
{
    public class RedPepper : ATopping
    {
        public RedPepper()
        {
            Name = "Red Pepper";
            Price = 0.25m;
            TOPPING = TOPPINGS.REDPEPPER;
        }
    }
}