using PizzaBox.Domain.Models.Components;
using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Storing.Entities.EntityModels
{
    /// <summary>
    /// Size entity model. Contains:
    /// ID
    /// SIZE (Enum instance)
    /// Price
    /// </summary>
    public class DBSize
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public SIZES SIZE { get; set; }
        [Required]
        public decimal? Price { get; set; }
    }
}