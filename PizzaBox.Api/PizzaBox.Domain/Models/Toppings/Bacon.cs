using PizzaBox.Domain.Models.Components;

namespace PizzaBox.Domain.Models.Toppings
{
    public class Bacon : ATopping
    {
        public Bacon()
        {
            Name = "Bacon";
            Price = 0.5m;
            TOPPING = TOPPINGS.BACON;
        }
    }
}