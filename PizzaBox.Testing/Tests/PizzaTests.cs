using PizzaBox.Domain.Models.Pizzas;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  /// <summary>
  /// 
  /// </summary>
  public class PizzaTests
  {
    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Test_PizzaCrust()
    {
      // arrange
      var sut = new VeganPizza();

      // act
      var actual = sut.Crust.Name;

      // assert
      Assert.Equal(actual, "Thin Crust");
    }

    [Fact]
    public void Test_PizzaSize()
    {
      // arrange
      var sut = new HawaiianPizza();

      // act
      var actual = sut.Size.Name;

      // assert
      Assert.Equal(actual, "Large");
    }

    [Fact]
    public void Test_PizzaPrice()
    {
      // arrange
      var sut = new MeatPizza();

      // act
      var actual = sut.CalculatePrice();

      // assert
      Assert.True(actual == (decimal)11.5);
    }
  }
}
