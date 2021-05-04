using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models.Components
{
    /// <summary>
    /// Enum containing all possible sizes.
    /// </summary>
    public enum SIZES
    {
        SMALL,
        MEDIUM,
        LARGE
    }

    /// <summary>
    /// 
    /// </summary>
    public class ASize : AComponent
    {
        public SIZES SIZE { get; set; }
    }
}
