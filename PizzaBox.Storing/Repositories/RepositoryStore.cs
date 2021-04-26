using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Entities.EntityModels;
using PizzaBox.Storing.Mappers;

namespace PizzaBox.Storing.Repositories
{
    public class RepositoryStore : IRepository<AStore>
    {
        public readonly PizzaDbContext context;
        public readonly MapperStore mapperStore = new MapperStore();

        public RepositoryStore(PizzaDbContext context)
        {
            this.context = context;
        }

        public void Add(AStore genericType)
        {
            context.Add(mapperStore.Map(genericType, context));
            context.SaveChanges();
            context.ChangeTracker.Clear();
        }

        public List<AStore> GetList()
        {
            return context.DBStores.AsNoTracking().Select(mapperStore.Map).ToList();
        }

        public AStore GetById(int id)
        {
            var dbStore = context.DBStores.AsNoTracking().FirstOrDefault(store => store.ID == id);

            if (dbStore is null)
            {
                return null;
            }

            return mapperStore.Map(dbStore);
        }

        public void Remove(int id)
        {
            DBStore existingStore = context.DBStores.ToList().Find(store => store.ID == id);

            if (existingStore is not null)
            {
                context.Remove(existingStore);
                context.SaveChanges();
                context.ChangeTracker.Clear();
            }
        }

        public AStore Update(AStore updated)
        {
            var dBStore = mapperStore.Map(updated, context);
            context.SaveChanges();
            return mapperStore.Map(dBStore);
        }
    }
}