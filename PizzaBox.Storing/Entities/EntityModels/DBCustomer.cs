using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Storing.Entities.EntityModels
{
  /// <summary>
  /// Customer entity model. Contains:
  /// ID
  /// Name
  /// </summary>
  public class DBCustomer
  {
    [Key]
    public int ID { get; set; }
    [Required]
    public string Name { get; set; }
  }
}