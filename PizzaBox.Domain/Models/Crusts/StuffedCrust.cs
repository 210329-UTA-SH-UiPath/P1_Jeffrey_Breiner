using PizzaBox.Domain.Models.Components;

namespace PizzaBox.Domain.Models.Crusts
{
  public class StuffedCrust : Crust
  {
    public StuffedCrust()
    {
      Name = "Stuffed Crust";
      Price = 2m;
    }
  }
}