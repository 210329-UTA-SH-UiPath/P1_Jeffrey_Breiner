using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models.Pizzas;

namespace PizzaBox.Client.Singletons
{
  /// <summary>
  /// 
  /// </summary>
  public class PizzaSingleton
  {
    private static PizzaSingleton _instance;

    public List<APizza> Pizzas { get; set; }
    public static PizzaSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new PizzaSingleton();
        }

        return _instance;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    private PizzaSingleton()
    {
      Pizzas = new List<APizza>()       //this is a list with its values set, not a functioon deffinition
      {
        new CustomPizza(null, null, null),
        new MeatPizza(),
        new HawaiianPizza(),
        new VeganPizza()
      };
    }
  }
}
