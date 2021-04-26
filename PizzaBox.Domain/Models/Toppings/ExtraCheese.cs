using PizzaBox.Domain.Models.Components;

namespace PizzaBox.Domain.Models.Toppings
{
    public class ExtraCheese : ATopping
    {
        public ExtraCheese()
        {
            Name = "Extra Cheese";
            Price = 0.5m;
            TOPPING = TOPPINGS.EXTRACHEESE;
        }
    }
}