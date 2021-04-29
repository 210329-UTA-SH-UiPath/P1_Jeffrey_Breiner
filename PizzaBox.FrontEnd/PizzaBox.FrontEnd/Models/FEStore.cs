using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.FrontEnd.Models
{
    public enum STORES
    {
        NEWYORK,
        CHICAGO
    }
    public class FEStore
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public STORES STORE { get; set; }
    }
}
