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
    void Remove(GenericType genericType);

    void update(GenericType existingType, GenericType updatedType);
  }
}