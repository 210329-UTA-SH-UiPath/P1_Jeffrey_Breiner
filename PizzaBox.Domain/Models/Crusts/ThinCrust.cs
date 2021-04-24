using PizzaBox.Domain.Models.Components;

namespace PizzaBox.Domain.Models.Crusts
{
  public class ThinCrust : Crust
  {
    public ThinCrust()
    {
      Name = "Thin Crust";
      Price = 1m;
    }
  }
}