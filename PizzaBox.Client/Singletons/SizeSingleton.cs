using System.Collections.Generic;
using PizzaBox.Domain.Models.Components;
using PizzaBox.Domain.Models.Sizes;

namespace PizzaBox.Client.Singletons
{
  /// <summary>
  /// 
  /// </summary>
  public class SizeSingleton
  {
    private static SizeSingleton _instance;

    public List<Size> Sizes { get; set; }
    public static SizeSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new SizeSingleton();
        }

        return _instance;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    private SizeSingleton()
    {
      Sizes = new List<Size>()
      {
        new SmallSize(),
        new MediumSize(),
        new LargeSize()
      };
    }
  }
}
