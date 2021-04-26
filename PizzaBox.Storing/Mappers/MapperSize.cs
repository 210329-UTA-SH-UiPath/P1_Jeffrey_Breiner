using System;
using System.Linq;
using PizzaBox.Domain.Models.Components;
using PizzaBox.Domain.Models.Sizes;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Entities.EntityModels;

namespace PizzaBox.Storing.Mappers
{
    public class MapperSize : IMapper<ASize, DBSize>
    {
        /// <summary>
        /// Map DBSize => Size
        /// Uses enum to determine which size class to return.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ASize Map(DBSize entity)
        {
            ASize size = null;

            switch (entity.SIZE)
            {
                case SIZES.SMALL:
                    size = new SmallSize();
                    break;
                case SIZES.MEDIUM:
                    size = new MediumSize();
                    break;
                case SIZES.LARGE:
                    size = new LargeSize();
                    break;
                default:
                    throw new ArgumentException("Size not recognized. Size could not be mapped properly");
            }

            size.ID = entity.ID;
            return size;
        }

        /// <summary>
        /// Map Size => DBSize
        /// Sets enum bassed off what size class was passed into it.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DBSize Map(ASize model, PizzaDbContext context)
        {
            DBSize dBSize = new DBSize();
            SIZES SIZE;

            switch (model)
            {
                case SmallSize:
                    SIZE = SIZES.SMALL;
                    break;
                case MediumSize:
                    SIZE = SIZES.MEDIUM;
                    break;
                case LargeSize:
                    SIZE = SIZES.LARGE;
                    break;
                default:
                    throw new ArgumentException("Size type not recognized. Size could not be mapped properly");
            }

            var dbSize = context.DBSizes.FirstOrDefault(size => size.SIZE == SIZE);
            if (dbSize is not null)
            {
                return dbSize;
            }

            dBSize.SIZE = SIZE;
            dBSize.Price = model.Price;
            return dBSize;
        }
    }
}