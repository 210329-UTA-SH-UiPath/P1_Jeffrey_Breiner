using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Storing.Entities.EntityModels
{
  /// <summary>
  /// Enum containing all possible toppings.
  /// </summary>
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