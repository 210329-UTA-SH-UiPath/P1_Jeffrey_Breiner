using System;
using System.Collections.Generic;
using System.Text;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  /// <summary>
  /// 
  /// </summary>
  public class Order
  {
    public AStore Store { get; set; }
    public Customer Customer { get; set; }
    public List<APizza> Pizza { get; set; }
    public decimal priceTotal;
    public DateTime TimeStamp { get; set; }

    public Order()
    {
      Customer = new Customer();
      Pizza = new List<APizza>();
    }

    public override string ToString()
    {
      int index = 0;
      StringBuilder buffer = new StringBuilder();
      foreach (var item in Pizza)
      {
        buffer.AppendLine($"{++index} - {item}");
      }
      buffer.AppendLine($"Order total: ${CalculateOrderPrice()}");
      return buffer.ToString();
    }

    public virtual decimal CalculateOrderPrice()
    {
      priceTotal = 0;
      foreach (var item in Pizza)
      {
        priceTotal += item.CalculatePrice();
      }
      return priceTotal;
    }

    /// <summary>
    /// 
    /// </summary>
    public void Save()
    {

    }
  }
}