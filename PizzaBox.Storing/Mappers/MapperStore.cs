using System;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Entities.EntityModels;

namespace PizzaBox.Storing.Mappers
{
  public class MapperStore : IMapper<AStore, DBStore>
  {
    /// <summary>
    /// Map DBStore => AStore
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public AStore Map(DBStore entity)
    {
      AStore store = null;

      switch (entity.STORE)
      {
        case Entities.EntityModels.STORES.NEWYORK:
          store = new NewYorkStore();
          break;
        case Entities.EntityModels.STORES.CHICAGO:
          store = new ChicagoStore();
          break;
        default:
          throw new ArgumentException("Store not recognized. Store could not be mapped properly");
      }

      store.ID = entity.ID;
      return store;
    }

    /// <summary>
    /// Map AStore => DBStore
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public DBStore Map(AStore model, PizzaDbContext context)
    {
      if (model.ID != -1)
      {
        var dbStore = context.DBStores.FirstOrDefault(store => store.ID == model.ID);

        if (dbStore is not null)
        {
          return dbStore;
        }
      }

      DBStore dBStore = new DBStore();
      Entities.EntityModels.STORES STORE;

      switch (model)
      {
        case NewYorkStore:
          STORE = Entities.EntityModels.STORES.NEWYORK;
          break;
        case ChicagoStore:
          STORE = Entities.EntityModels.STORES.CHICAGO;
          break;
        default:
          throw new ArgumentException("Store type not recognized. Store could not be mapped properly");
      }

      dBStore.Name = model.Name;
      dBStore.STORE = STORE;
      //dBStore.ID = model.ID;
      return dBStore;
    }
  }
}