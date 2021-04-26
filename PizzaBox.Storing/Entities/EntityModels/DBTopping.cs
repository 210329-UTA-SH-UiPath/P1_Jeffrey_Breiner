using PizzaBox.Domain.Models.Components;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Storing.Entities.EntityModels
{
    /// <summary>
    /// Topping entity model. Contains:
    /// ID
    /// TOPPING (Enum instance)
    /// Price
    /// </summary>
    public class DBTopping
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public TOPPINGS TOPPING { get; set; }
        [Required]
        public decimal? Price { get; set; }
        public List<DBPlacedTopping> DBPlacedToppings { get; set; }
    }
}