using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models.Components
{
    /// <summary>
    /// Enum containing all possible crusts.
    /// </summary>
    public enum CRUSTS
    {
        DEEPDISH,
        STANDARD,
        STUFFED,
        THIN
    }

    /// <summary>
    /// 
    /// </summary>
    public class ACrust : AComponent
    {
        public CRUSTS CRUST { get; set; }
    }
}