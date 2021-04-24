using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Storing.Entities.EntityModels
{
  /// <summary>
  /// Enum containing all stores.
  /// </summary>
  public enum STORES
  {
    NEWYORK,
    CHICAGO
  }

  /// <summary>
  /// Store entity model. Contains:
  /// ID
  /// STORE (Enum instance)
  /// </summary>
  public class DBStore
  {
    [Key]
    public int ID { get; set; }
    [Required]
    public STORES STORE { get; set; }
    [Required]
    public string Name { get; set; }
  }
}