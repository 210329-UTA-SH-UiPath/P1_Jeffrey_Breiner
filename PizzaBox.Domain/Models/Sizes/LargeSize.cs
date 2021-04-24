using PizzaBox.Domain.Models.Components;

namespace PizzaBox.Domain.Models.Sizes
{
  public class LargeSize : Size
  {
    public LargeSize()
    {
      Name = "Large";
      Price = 12m;
    }
  }
}