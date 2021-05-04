using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.FrontEnd.Models
{
    public enum TOPPINGS
    {
        BACON,
        CHICKEN,
        EXTRACHEESE,
        GREENPEPPER,
        HAM,
        NOCHEESE,
        PINEAPPLE,
        REDPEPPER,
        SAUSAGE
    }
    public class FETopping
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ID { get; set; }
        public TOPPINGS TOPPING { get; set; }
    }
}
