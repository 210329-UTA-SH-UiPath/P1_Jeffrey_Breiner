using System.Collections.Generic;
using System.Linq;
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
    }

    public List<AStore> GetList()
    {
      List<AStore> aStores = new List<AStore>();
      context.DBStores.AsEnumerable().GroupBy(store => store.Name).Select(store => store.First()).ToList().ForEach(store => aStores.Add(mapperStore.Map(store)));
      return aStores;
    }

    public void Remove(AStore genericType)
    {
      DBStore existingStore = context.DBStores.ToList().Find(store => store.Name.Equals(genericType.Name));

      if (existingStore is not null)
      {
        context.Remove(existingStore);
        context.SaveChanges();
      }
    }

    public void update(AStore existingType, AStore updatedType)
    {
      DBStore existingStore = context.DBStores.ToList().Find(store => store.Name.Equals(existingType.Name));

      if (existingStore is not null)
      {
        DBStore EntityMapped = mapperStore.Map(updatedType, context);
        existingStore.Name = EntityMapped.Name;
        existingStore.STORE = EntityMapped.STORE;
        context.SaveChanges();
      }
    }
  }
}