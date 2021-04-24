using PizzaBox.Domain.Models.Components;

namespace PizzaBox.Domain.Models.Toppings
{
  public class RedPepper : Topping
  {
    public RedPepper()
    {
      Name = "Red Pepper";
      Price = 0.25m;
    }
  }
}