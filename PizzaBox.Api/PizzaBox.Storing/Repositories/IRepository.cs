using System.Collections.Generic;

namespace PizzaBox.Storing.Repositories
{
    /// <summary>
    /// Universal repository interface.
    /// </summary>
    /// <typeparam name="GenericType"></typeparam>
    public interface IRepository<GenericType>
    {
        void Add(GenericType genericType);
        List<GenericType> GetList();
        GenericType GetById(int id);
        void Remove(int id);

        GenericType Update(GenericType updatedType);
    }
}