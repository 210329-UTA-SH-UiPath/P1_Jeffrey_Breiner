namespace PizzaBox.Domain.Abstracts
{
  /// <summary>
  /// A component of the pizza. could be a Size, Crust, Topping, etc.
  /// </summary>
  public class AComponent
  {
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int ID { get; set; }

    public override string ToString()
    {
      return Name;
    }
  }
}