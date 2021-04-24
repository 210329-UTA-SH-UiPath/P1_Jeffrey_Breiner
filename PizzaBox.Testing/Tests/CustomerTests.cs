using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Pizzas;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  public class CustomerTests
  {
    [Fact]
    public void Test_Customer()
    {
      // arrange
      var sut = new Customer();

      // act
      sut.Name = "yes";
      var actual = sut.Name;

      // assert
      Assert.Equal(actual, "yes");
    }

    [Fact]
    public void Test_Customer2()
    {
      // arrange
      var sut = new Customer();

      // act
      sut.Name = "BOGGLE!";
      var actual = sut.Name;

      // assert
      Assert.Equal(actual, "BOGGLE!");
    }
  }
}