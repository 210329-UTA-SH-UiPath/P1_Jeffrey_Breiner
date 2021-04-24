using PizzaBox.Domain.Models.Components;

namespace PizzaBox.Domain.Models.Toppings
{
  public class GreenPepper : Topping
  {
    public GreenPepper()
    {
      Name = "Green Pepper";
      Price = 0.25m;
    }
  }
}