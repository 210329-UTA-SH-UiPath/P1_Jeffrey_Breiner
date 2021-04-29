using PizzaBox.Domain.Abstracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PizzaBox.Storing.Entities.EntityModels
{
    /// <summary>
    /// Pizza entity model. Contains:
    /// ID
    /// PIZZA (Enum instance)
    /// DBCrust
    /// DBSize
    /// DBToppings (list)
    /// Price
    /// </summary>
    public class DBPizza
    {
        public DBPizza()
        {
            DBPlacedToppings = new List<DBPlacedTopping>();
        }
        [Key]
        public int ID { get; set; }
        [Required]
        public PIZZAS PIZZA { get; set; }
        [Required]
        public DBCrust DBCrust { get; set; }
        [Required]
        public DBSize DBSize { get; set; }
        [Required]
        public List<DBPlacedTopping> DBPlacedToppings { get; set; }
        [Required]
        public decimal? Price { get; set; }
    }
}