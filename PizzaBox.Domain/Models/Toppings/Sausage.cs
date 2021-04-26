using PizzaBox.Domain.Models.Components;

namespace PizzaBox.Domain.Models.Toppings
{
    public class Sausage : ATopping
    {
        public Sausage()
        {
            Name = "Sausage";
            Price = 0.5m;
            TOPPING = TOPPINGS.SAUSAGE;
        }
    }
}