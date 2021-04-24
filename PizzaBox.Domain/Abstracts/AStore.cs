using System.Xml.Serialization;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
  /// <summary>
  /// Represents the Store Abstract Class
  /// </summary>
  [XmlInclude(typeof(ChicagoStore))]
  [XmlInclude(typeof(NewYorkStore))]
  public class AStore
  {
    public string Name { get; set; }
    public int ID { get; set; }

    /// <summary>
    /// 
    /// </summary>
    protected AStore()
    {
      ID = -1;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      return $"{Name}";
    }
  }
}