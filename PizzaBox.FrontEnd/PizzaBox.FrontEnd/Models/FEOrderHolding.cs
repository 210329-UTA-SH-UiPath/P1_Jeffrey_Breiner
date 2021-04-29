using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PizzaBox.FrontEnd.Models;

namespace PizzaBox.Client.Models
{
    public class FEOrderHolding
    {

        public FEOrderHolding()
        {
            Order = new FEOrder();
        }
        public FEOrder Order { get; set; }
        public int Place { get; set; }
        public PIZZAS PIZZA { get; set; }
        public CRUSTS CRUSt { get; set; }
        public SIZES SIZE { get; set; }
        public TOPPINGS TOPPING { get; set; }
    }
}