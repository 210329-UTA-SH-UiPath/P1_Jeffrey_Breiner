using System.Collections.Generic;
using System.Text;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Components;
using PizzaBox.Domain.Models.Pizzas;

namespace PizzaBox.Domain.Abstracts
{
  /// <summary>
  /// Pizza object. Contains Crust, Size, and a list of Toppings.
  /// Also contains functions to add those elements.
  /// </summary>
  public abstract class APizza
  {
    public string Name { get; set; }
    public Crust Crust { get; set; }
    public Size Size { get; set; }
    public List<Topping> Toppings { get; set; }
    public decimal price;

    protected APizza()
    {
      Factory();
    }

    protected APizza(Crust crust, Size size, List<Topping> toppings)
    {

    }

    private void Factory()
    {
      Toppings = new List<Topping>();

      AddCrust();
      AddSize();
      AddToppings();
    }

    private void Factory(Crust crust, Size size, List<Topping> toppings)
    {
      AddCrust(crust);
    }

    public virtual void AddCrust()
    {
      Crust = new Crust();
    }

    public virtual void AddCrust(Crust crust)
    {

    }

    public virtual void AddSize()
    {
      Size = new Size();
    }

    public abstract void AddToppings();

    public virtual decimal CalculatePrice()
    {
      decimal price = Crust.Price + Size.Price;
      foreach (var item in Toppings)
      {
        price += item.Price;
      }
      return price;
    }

    public override string ToString()
    {
      StringBuilder buffer = new StringBuilder();

      if (this is CustomPizza)
      {
        buffer.AppendLine($"{Name}:");
        buffer.AppendLine($"    - {Crust} Crust: ${Crust.Price}");
        buffer.AppendLine($"    - {Size} Size: ${Size.Price}");
        buffer.AppendLine($"    - Toppings:");
        foreach (var item in Toppings)
        {
          buffer.AppendLine($"      - {item}: ${item.Price}");
        }

        buffer.AppendLine($"    Price: ${CalculatePrice()}");
        return buffer.ToString();
      }
      else
      {
        return $"{Name}: ${CalculatePrice()}";
      }
    }
  }
}