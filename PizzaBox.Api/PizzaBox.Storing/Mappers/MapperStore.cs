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
                case STORES.NEWYORK:
                    store = new NewYorkStore();
                    break;
                case STORES.CHICAGO:
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
        public DBStore Map(AStore model, PizzaDbContext context, bool update = false)
        {
            DBStore dbStore = context.DBStores.FirstOrDefault(store => store.ID == model.ID) ?? new DBStore();
            if (dbStore.ID != 0 && !update)
            {
                return dbStore;
            }
            dbStore.Name = model.Name;
            dbStore.STORE = model.STORE;
            if (dbStore.ID == 0)
            {
                context.DBStores.Add(dbStore);
            }
            return dbStore;
        }
    }
}