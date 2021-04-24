using PizzaBox.Domain.Models.Components;

namespace PizzaBox.Domain.Models.Toppings
{
  /// <summary>
  /// This class only exists to allow the user to choose not to add a toping 
  /// </summary>
  public class NoChoice : Topping
  {
    public NoChoice()
    {
      Name = "No more toppings";
      Price = 0m;
    }
  }
}