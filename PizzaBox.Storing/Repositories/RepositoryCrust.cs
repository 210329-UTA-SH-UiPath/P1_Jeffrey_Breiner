using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models.Components;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Entities.EntityModels;
using PizzaBox.Storing.Mappers;

namespace PizzaBox.Storing.Repositories
{
    public class RepositoryCrust : IRepository<ACrust>
    {
        public readonly PizzaDbContext context;
        public readonly MapperCrust mapperCrust = new MapperCrust();

        public RepositoryCrust(PizzaDbContext context)
        {
            this.context = context;
        }

        public void Add(ACrust genericType)
        {
            context.DBCrusts.Add(mapperCrust.Map(genericType, context));
            context.SaveChanges();
            context.ChangeTracker.Clear();
        }

        /// <returns></returns>
        public List<ACrust> GetList()
        {
            return context.DBCrusts.AsNoTracking().Select(mapperCrust.Map).ToList();
        }

        public ACrust GetById(int id)
        {
            var dbCrust = context.DBCrusts.AsNoTracking().FirstOrDefault(crust => crust.ID == id);

            if (dbCrust is null)
            {
                return null;
            }

            return mapperCrust.Map(dbCrust);
        }

        public void Remove(int id)
        {
            DBCrust crust = context.DBCrusts.FirstOrDefault(crust => crust.ID == id);

            if (crust is not null)
            {
                context.Remove(crust);
                context.SaveChanges();
                context.ChangeTracker.Clear();
            }
        }

        public ACrust Update(ACrust updatedType)
        {
            DBCrust dBCrust = mapperCrust.Map(updatedType, context);
            context.SaveChanges();
            context.ChangeTracker.Clear();
            return mapperCrust.Map(dBCrust);
        }
    }
}