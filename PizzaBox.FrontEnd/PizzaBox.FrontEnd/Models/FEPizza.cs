using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox.FrontEnd.Models
{
    public enum PIZZAS
    {
        CUSTOM,
        HAWAIIAN,
        MEAT,
        VEGAN
    }
    public class FEPizza
    {
        public FEPizza()
        {
            Toppings = new List<FETopping>();
        }

        public string Name { get; set; }
        public FECrust Crust { get; set; }
        public FESize Size { get; set; }
        public List<FETopping> Toppings { get; set; }
        public decimal Price { get; set; }
        public PIZZAS PIZZA { get; set; }
        public int ID { get; set; }

        public override string ToString()
        {
            StringBuilder buffer = new StringBuilder();

            if (PIZZA == PIZZAS.CUSTOM)
            {
                buffer.AppendLine($"{Size.Name} {Crust.Name} Custom Pizza with:");
                foreach (var item in Toppings)
                {
                    buffer.AppendLine($"      - {item.Name}: ${item.Price}");
                }

                buffer.AppendLine($"    Price: ${Price}");
                return buffer.ToString();
            }
            else
            {
                return $"{Name}: ${Price}";
            }
        }
    }
}
