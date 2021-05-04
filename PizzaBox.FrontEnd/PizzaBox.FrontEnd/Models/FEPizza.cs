using IO.Swagger.Model;
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
            Toppings = new List<ATopping>();
        }

        public string Name { get; set; }
        public FECrust Crust { get; set; }
        public ASize Size { get; set; }
        public List<ATopping> Toppings { get; set; }
        public decimal Price { get; set; }
        public PIZZAS PIZZA { get; set; }
        public int ID { get; set; }
    }
}
