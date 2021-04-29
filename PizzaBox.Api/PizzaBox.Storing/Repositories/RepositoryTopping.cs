using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models.Components;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Entities.EntityModels;
using PizzaBox.Storing.Mappers;

namespace PizzaBox.Storing.Repositories
{
    public class RepositoryTopping : IRepository<ATopping>
    {
        public readonly PizzaDbContext context;
        public readonly MapperTopping mapperTopping = new MapperTopping();

        public RepositoryTopping(PizzaDbContext context)
        {
            this.context = context;
        }

        public void Add(ATopping genericType)
        {
            context.DBToppings.Add(mapperTopping.Map(genericType, context));
            context.SaveChanges();
        }

        public List<ATopping> GetList()
        {
            return context.DBToppings.Select(mapperTopping.Map).ToList();
        }

        public ATopping GetById(int id)
        {
            var dbTopping = context.DBToppings.FirstOrDefault(topping => topping.ID == id);

            if (dbTopping is null)
            {
                return null;
            }

            return mapperTopping.Map(dbTopping);
        }

        public void Remove(int id)
        {
            DBTopping topping = context.DBToppings.FirstOrDefault(topping => topping.ID == id);

            if (topping is not null)
            {
                context.Remove(topping);
                context.SaveChanges();
            }
        }

        public ATopping Update(ATopping updatedType)
        {
            DBTopping dBTopping = mapperTopping.Map(updatedType, context);
            context.SaveChanges();
            return mapperTopping.Map(dBTopping);
        }
    }
}