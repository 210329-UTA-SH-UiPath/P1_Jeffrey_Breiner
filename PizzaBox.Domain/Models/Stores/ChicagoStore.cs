using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  /// <summary>
  /// 
  /// </summary>
  public class ChicagoStore : AStore
  {
    /// <summary>
    /// 
    /// </summary>
    public ChicagoStore()
    {
      Name = "Chicago Store";
    }

    public override string ToString()
    {
      return $"{Name} - Chitown";
    }
  }
}