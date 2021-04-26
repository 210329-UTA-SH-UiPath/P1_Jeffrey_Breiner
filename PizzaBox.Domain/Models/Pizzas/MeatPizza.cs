using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models.Components;
using PizzaBox.Domain.Models.Crusts;
using PizzaBox.Domain.Models.Sizes;
using PizzaBox.Domain.Models.Toppings;

namespace PizzaBox.Domain.Models.Pizzas
{
    /// <summary>
    /// Premade Pizza
    /// </summary>
    public class MeatPizza : APizza
    {
        public MeatPizza()
        {
            Name = "Meat Pizza";
            PIZZA = PIZZAS.MEAT;
        }

        public override void AddCrust()
        {
            Crust = new StuffedCrust();
        }

        public override void AddSize()
        {
            Size = new MediumSize();
        }

        public override void AddToppings()
        {
            Toppings.AddRange(new ATopping[] { new Bacon(), new Ham(), new Sausage() });
        }
    }
}
