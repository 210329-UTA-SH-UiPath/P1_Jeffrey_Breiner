using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models.Components;

namespace PizzaBox.Domain.Models.Pizzas
{
  public class CustomPizza : APizza
  {
    public CustomPizza(Crust crust, Size size, List<Topping> topping)
    {
      Name = "Custom Pizza";
      Crust = crust;
      Size = size;
      Toppings = topping;
    }

    public override void AddCrust()
    {

    }

    public override void AddSize()
    {

    }

    public override void AddToppings()
    {

    }
  }
}