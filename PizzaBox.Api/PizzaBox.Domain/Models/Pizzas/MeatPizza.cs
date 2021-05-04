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
        public MeatPizza(ASize size)
        {
            Name = "Meat Pizza";
            PIZZA = PIZZAS.MEAT;
            AddSize(size);
        }

        public override void AddCrust()
        {
            Crust = new StuffedCrust();
        }

        public override void AddSize(ASize size)
        {
            Size = size;
        }

        public override void AddToppings()
        {
            Toppings.AddRange(new ATopping[] { new Bacon(), new Ham(), new Sausage() });
        }
    }
}
