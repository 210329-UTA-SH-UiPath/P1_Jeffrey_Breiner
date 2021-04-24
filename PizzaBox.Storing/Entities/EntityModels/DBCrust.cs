

using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Storing.Entities.EntityModels
{
  /// <summary>
  /// Enum containing all possible crusts.
  /// </summary>
  public enum CRUSTS
  {
    DEEPDISH,
    STANDARD,
    STUFFED,
    THIN
  }

  /// <summary>
  /// Crust entity model. Contains:
  /// ID
  /// CRUST (Enum instance)
  /// Price
  /// </summary>
  public class DBCrust
  {
    [Key]
    public int ID { get; set; }
    [Required]
    public CRUSTS CRUST { get; set; }
    [Required]
    public decimal? Price { get; set; }
  }
}