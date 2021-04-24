using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Storing.Entities.EntityModels
{
  public class DBPlacedTopping
  {
    [Key]
    public int ID { get; set; }
    [Required]
    public virtual DBPizza Pizza { get; set; }
    [Required]
    public virtual DBTopping Topping { get; set; }
  }
}