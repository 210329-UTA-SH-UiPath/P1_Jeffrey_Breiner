using PizzaBox.Domain.Models.Components;

namespace PizzaBox.Domain.Models.Toppings
{
  public class Bacon : Topping
  {
    public Bacon()
    {
      Name = "Bacon";
      Price = 0.5m;
    }
  }
}