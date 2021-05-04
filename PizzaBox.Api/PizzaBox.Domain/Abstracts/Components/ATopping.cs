using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models.Components
{
    /// <summary>
    /// Enum containing all possible toppings.
    /// </summary>
    public enum TOPPINGS
    {
        BACON,
        CHICKEN,
        EXTRACHEESE,
        GREENPEPPER,
        HAM,
        NOCHEESE,
        PINEAPPLE,
        REDPEPPER,
        SAUSAGE
    }

    /// <summary>
    /// 
    /// </summary>
    public class ATopping : AComponent
    {
        public TOPPINGS TOPPING { get; set; }
    }
}
