using PizzaBox.Domain.Models.Components;

namespace PizzaBox.Domain.Models.Sizes
{
  public class SmallSize : Size
  {
    public SmallSize()
    {
      Name = "Small";
      Price = 5m;
    }
  }
}