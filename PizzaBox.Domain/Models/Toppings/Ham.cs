using PizzaBox.Domain.Models.Components;

namespace PizzaBox.Domain.Models.Toppings
{
  public class Ham : Topping
  {
    public Ham()
    {
      Name = "Ham";
      Price = 0.5m;
    }
  }
}