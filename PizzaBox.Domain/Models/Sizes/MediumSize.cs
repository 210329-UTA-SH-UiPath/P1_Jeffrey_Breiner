using PizzaBox.Domain.Models.Components;

namespace PizzaBox.Domain.Models.Sizes
{
  public class MediumSize : Size
  {
    public MediumSize()
    {
      Name = "Medium";
      Price = 8m;
    }
  }
}