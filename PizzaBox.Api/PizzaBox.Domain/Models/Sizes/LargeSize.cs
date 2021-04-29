using PizzaBox.Domain.Models.Components;

namespace PizzaBox.Domain.Models.Sizes
{
    public class LargeSize : ASize
    {
        public LargeSize()
        {
            Name = "Large";
            Price = 12m;
            SIZE = SIZES.LARGE;
        }
    }
}