using System.Collections.Generic;
using PizzaBox.Client.Singletons;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Domain.Singletons
{
  /// <summary>
  /// Contains aan _instance of itself that is created by through the Instance of itself.
  /// Also contains a file path and reads from that file for its constructor.
  /// </summary>
  public class StoreSingleton
  {
    private static StoreSingleton _instance;
    private static readonly RepositoryStore _storeRepository = new RepositoryStore(DbContextSingleton.Instance.Context);
    private const string _path = @"store.xml";
    public List<AStore> Stores { get; set; }
    public static StoreSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new StoreSingleton();
        }

        return _instance;
      }
    }

    /// <summary>
    /// Constructor. Sets a list of stores from a file.
    /// </summary>
    private StoreSingleton()
    {
      Stores = _storeRepository.GetList();
    }
  }
}