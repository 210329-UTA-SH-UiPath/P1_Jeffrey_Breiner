using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models.Components;

namespace PizzaBox.Domain.Models.Pizzas
{
    public class CustomPizza : APizza
    {
        public CustomPizza(ACrust crust, ASize size, List<ATopping> topping)
        {
            Name = "Custom Pizza";
            Crust = crust;
            Size = size;
            Toppings = topping;
        }

        public override void AddCrust()
        {

        }

        public override void AddSize(ASize size)
        {

        }

        public override void AddToppings()
        {

        }
    }
}