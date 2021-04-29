using PizzaBox.Domain.Models.Components;

namespace PizzaBox.Domain.Models.Crusts
{
    public class ThinCrust : ACrust
    {
        public ThinCrust()
        {
            Name = "Thin Crust";
            Price = 1m;
            CRUST = CRUSTS.THIN;
        }
    }
}