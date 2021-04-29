using System.Collections.Generic;
using System.Text;
using PizzaBox.Domain.Models.Components;
using PizzaBox.Domain.Models.Pizzas;

namespace PizzaBox.Domain.Abstracts
{
    /// <summary>
    /// Enum containing all possible premade pizzas. Also contains custom pizza.
    /// </summary>
    public enum PIZZAS
    {
        CUSTOM,
        HAWAIIAN,
        MEAT,
        VEGAN
    }

    /// <summary>
    /// Pizza object. Contains Crust, Size, and a list of Toppings.
    /// Also contains functions to add those elements.
    /// </summary>
    public abstract class APizza
    {
        public string Name { get; set; }
        public ACrust Crust { get; set; }
        public ASize Size { get; set; }
        public List<ATopping> Toppings { get; set; }
        public decimal Price { get; set; }
        public PIZZAS PIZZA { get; set; }
        public int ID { get; set; }

        protected APizza()
        {
            Factory();
        }

        protected APizza(ACrust crust, ASize size, List<ATopping> toppings)
        {

        }

        private void Factory()
        {
            Toppings = new List<ATopping>();

            AddCrust();
            AddSize();
            AddToppings();
        }

        public abstract void AddCrust();

        public abstract void AddSize();

        public abstract void AddToppings();

        public virtual decimal CalculatePrice()
        {
            Price = Crust.Price + Size.Price;
            foreach (var item in Toppings)
            {
                Price += item.Price;
            }
            return Price;
        }

        public override string ToString()
        {
            StringBuilder buffer = new StringBuilder();

            if (this is CustomPizza)
            {
                buffer.AppendLine($"{Name}:");
                buffer.AppendLine($"    - {Crust} Crust: ${Crust.Price}");
                buffer.AppendLine($"    - {Size} Size: ${Size.Price}");
                buffer.AppendLine($"    - Toppings:");
                foreach (var item in Toppings)
                {
                    buffer.AppendLine($"      - {item}: ${item.Price}");
                }

                buffer.AppendLine($"    Price: ${CalculatePrice()}");
                return buffer.ToString();
            }
            else
            {
                return $"{Name}: ${CalculatePrice()}";
            }
        }
    }
}