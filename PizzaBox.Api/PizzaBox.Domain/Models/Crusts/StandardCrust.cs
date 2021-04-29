using PizzaBox.Domain.Models.Components;

namespace PizzaBox.Domain.Models.Crusts
{
    public class StandardCrust : ACrust
    {
        public StandardCrust()
        {
            Name = "Standard Crust";
            Price = 1.5m;
            CRUST = CRUSTS.STANDARD;
        }
    }
}