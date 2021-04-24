using System.Collections.Generic;
using PizzaBox.Domain.Models.Components;
using PizzaBox.Domain.Models.Toppings;

namespace PizzaBox.Client.Singletons
{
  /// <summary>
  /// 
  /// </summary>
  public class ToppingSingleton
  {
    private static ToppingSingleton _instance;

    public List<Topping> Toppings { get; set; }
    public static ToppingSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new ToppingSingleton();
        }

        return _instance;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    private ToppingSingleton()
    {
      Toppings = new List<Topping>()
      {
        new NoChoice(),
        new Bacon(),
        new Chicken(),
        new ExtraCheese(),
        new GreenPepper(),
        new Ham(),
        new NoCheese(),
        new Pineapple(),
        new RedPepper(),
        new Sausage()
      };
    }
  }
}
