using System;
using System.Linq;
using PizzaBox.Domain.Models.Components;
using PizzaBox.Domain.Models.Crusts;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Entities.EntityModels;

namespace PizzaBox.Storing.Mappers
{
    public class MapperCrust : IMapper<ACrust, DBCrust>
    {
        /// <summary>
        /// Map DBCrust => Crust
        /// Uses enum to determine which crust class to return.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ACrust Map(DBCrust entity)
        {
            ACrust crust = null;

            switch (entity.CRUST)
            {
                case CRUSTS.DEEPDISH:
                    crust = new DeepDishCrust();
                    break;
                case CRUSTS.STANDARD:
                    crust = new StandardCrust();
                    break;
                case CRUSTS.STUFFED:
                    crust = new StuffedCrust();
                    break;
                case CRUSTS.THIN:
                    crust = new ThinCrust();
                    break;
                default:
                    throw new ArgumentException("Crust type not recognized. Crust could not be mapped properly");
            }

            crust.ID = entity.ID;
            return crust;
        }

        /// <summary>
        /// Map Crust => DBCrust
        /// Sets enum bassed off what crust class was passed into it.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DBCrust Map(ACrust model, PizzaDbContext context, bool update = false)
        {
            DBCrust dbCrust = context.DBCrusts.FirstOrDefault(crust => crust.ID == model.ID) ?? new DBCrust();
            if (dbCrust.ID != 0 && !update)
            {
                return dbCrust;
            }

            dbCrust.CRUST = model.CRUST;
            dbCrust.Price = model.Price;

            if (dbCrust.ID == 0)
            {
                context.DBCrusts.Add(dbCrust);
            }
            return dbCrust;
        }
    }
}