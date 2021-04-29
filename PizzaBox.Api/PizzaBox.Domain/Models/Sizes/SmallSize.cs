using PizzaBox.Domain.Models.Components;

namespace PizzaBox.Domain.Models.Sizes
{
    public class SmallSize : ASize
    {
        public SmallSize()
        {
            Name = "Small";
            Price = 5m;
            SIZE = SIZES.SMALL;
        }
    }
}