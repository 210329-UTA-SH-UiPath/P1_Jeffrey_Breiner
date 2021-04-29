using PizzaBox.Domain.Models.Components;

namespace PizzaBox.Domain.Models.Sizes
{
    public class MediumSize : ASize
    {
        public MediumSize()
        {
            Name = "Medium";
            Price = 8m;
            SIZE = SIZES.MEDIUM;
        }
    }
}