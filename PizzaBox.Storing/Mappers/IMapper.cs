using PizzaBox.Storing.Entities;

namespace PizzaBox.Storing.Mappers
{
    /// <summary>
    /// Universal mapper interface.
    /// </summary>
    /// <typeparam name="Model"></typeparam>
    /// <typeparam name="Entity"></typeparam>
    public interface IMapper<Model, Entity>
    {
        Model Map(Entity entity);
        Entity Map(Model model, PizzaDbContext context);
    }
}