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
    public VeganPizza()
    {
      Name = "Vegan (Abomination) Pizza";
    }
    public override void AddCrust()
    {
      Crust = new ThinCrust();
    }

    public override void AddSize()
    {
      Size = new SmallSize();
    }

    public override void AddToppings()
    {
      Toppings.AddRange(new Topping[] { new NoCheese(), new GreenPepper(), new RedPepper() });
    }
  }
}
