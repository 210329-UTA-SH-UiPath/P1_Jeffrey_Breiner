using PizzaBox.Domain.Models.Components;

namespace PizzaBox.Domain.Models.Crusts
{
  public class StandardCrust : Crust
  {
    public StandardCrust()
    {
      Name = "Standard Crust";
      Price = 1.5m;
    }
  }
}