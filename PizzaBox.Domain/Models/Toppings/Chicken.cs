using PizzaBox.Domain.Models.Components;

namespace PizzaBox.Domain.Models.Toppings
{
  public class Chicken : Topping
  {
    public Chicken()
    {
      Name = "Chicken";
      Price = 0.5m;
    }
  }
}