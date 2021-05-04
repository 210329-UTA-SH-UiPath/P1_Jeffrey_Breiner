using PizzaBox.Domain.Models.Pizzas;
using PizzaBox.Domain.Models.Sizes;
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
            var sut = new VeganPizza(new SmallSize());

            // act
            var actual = sut.Crust.Name;

            // assert
            Assert.Equal("Thin Crust", actual);
        }

        [Fact]
        public void Test_PizzaSize()
        {
            // arrange
            var sut = new HawaiianPizza(new LargeSize());

            // act
            var actual = sut.Size.Name;

            // assert
            Assert.Equal("Large", actual);
        }

        [Fact]
        public void Test_PizzaPrice()
        {
            // arrange
            var sut = new MeatPizza(new MediumSize());

            // act
            var actual = sut.CalculatePrice();

            // assert
            Assert.True(actual == (decimal)11.5);
        }
    }
}
