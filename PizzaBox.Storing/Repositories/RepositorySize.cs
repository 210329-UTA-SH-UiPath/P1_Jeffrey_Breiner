using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models.Components;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Entities.EntityModels;
using PizzaBox.Storing.Mappers;

namespace PizzaBox.Storing.Repositories
{
    public class RepositorySize : IRepository<ASize>
    {
        public readonly PizzaDbContext context;
        public readonly MapperSize mapperSize = new MapperSize();

        public RepositorySize(PizzaDbContext context)
        {
            this.context = context;
        }

        public void Add(ASize genericType)
        {
            context.DBSizes.Add(mapperSize.Map(genericType, context));
            context.SaveChanges();
            context.ChangeTracker.Clear();
        }

        public List<ASize> GetList()
        {
            return context.DBSizes.AsNoTracking().Select(mapperSize.Map).ToList();
        }

        public ASize GetById(int id)
        {
            var dbSize = context.DBSizes.AsNoTracking().FirstOrDefault(size => size.ID == id);

            if (dbSize is null)
            {
                return null;
            }

            return mapperSize.Map(dbSize);
        }

        public void Remove(int id)
        {
            DBSize size = context.DBSizes.ToList().Find(size => size.ID == id);

            if (size is not null)
            {
                context.Remove(size);
                context.SaveChanges();
                context.ChangeTracker.Clear();
            }
        }

        public ASize Update(ASize updatedType)
        {
            DBSize dBSize = mapperSize.Map(updatedType, context);
            context.SaveChanges();
            return mapperSize.Map(dBSize);
        }
    }
}