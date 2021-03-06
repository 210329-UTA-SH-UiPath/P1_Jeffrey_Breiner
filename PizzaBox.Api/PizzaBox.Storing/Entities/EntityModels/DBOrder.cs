using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace PizzaBox.Storing.Entities.EntityModels
{
    /// <summary>
    /// Oder entity model. Contains:
    /// ID
    /// DBStore
    /// DBCustomer
    /// Pizzas (list)
    /// PriceTotal
    /// TimeStamp
    /// </summary>
    public class DBOrder
    {
        public DBOrder()
        {
            //DBStore = new DBStore();
            //DBCustomer = new DBCustomer();
            TimeStamp = new DateTime();
            DBPizzas = new List<DBPizza>();
        }

        [Key]
        public int ID { get; set; }
        [Required]
        public DBStore DBStore { get; set; }
        [Required]
        public DBCustomer DBCustomer { get; set; }
        [Required]
        public virtual List<DBPizza> DBPizzas { get; set; }
        [Required]
        public decimal? PriceTotal { get; set; }
        [Required]
        public DateTime TimeStamp { get; set; }
    }
}
