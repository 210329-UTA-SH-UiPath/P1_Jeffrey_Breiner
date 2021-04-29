using PizzaBox.Domain.Models.Components;

namespace PizzaBox.Domain.Models.Crusts
{
    public class DeepDishCrust : ACrust
    {
        public DeepDishCrust()
        {
            Name = "Deep Dish Crust";
            Price = 2.5m;
            CRUST = CRUSTS.DEEPDISH;
        }
    }
}