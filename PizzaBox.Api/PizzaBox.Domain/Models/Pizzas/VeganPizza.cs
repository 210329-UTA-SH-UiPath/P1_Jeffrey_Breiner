using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models.Components;
using PizzaBox.Domain.Models.Crusts;
using PizzaBox.Domain.Models.Sizes;
using PizzaBox.Domain.Models.Toppings;

namespace PizzaBox.Domain.Models.Pizzas
{
    /// <summary>
    /// 
    /// </summary>
    public class VeganPizza : APizza
    {
        public VeganPizza(ASize size)
        {
            Name = "Vegan (Abomination) Pizza";
            PIZZA = PIZZAS.VEGAN;
            AddSize(size);
        }
        public override void AddCrust()
        {
            Crust = new ThinCrust();
        }

        public override void AddSize(ASize size)
        {
            Size = size;
        }

        public override void AddToppings()
        {
            Toppings.AddRange(new ATopping[] { new NoCheese(), new GreenPepper(), new RedPepper() });
        }
    }
}
