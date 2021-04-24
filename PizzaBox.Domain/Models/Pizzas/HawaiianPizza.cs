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
  public class HawaiianPizza : APizza
  {
    public HawaiianPizza()
    {
      Name = "Hawaiian Pizza";
    }

    public override void AddCrust()
    {
      Crust = new DeepDishCrust();
    }

    public override void AddSize()
    {
      Size = new LargeSize();
    }

    public override void AddToppings()
    {
      Toppings.AddRange(new Topping[] { new Pineapple(), new Ham() });
    }
  }
}
