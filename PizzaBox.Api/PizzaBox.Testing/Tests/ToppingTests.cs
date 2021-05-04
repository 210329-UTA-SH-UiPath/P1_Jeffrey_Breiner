using PizzaBox.Domain.Models.Toppings;
using Xunit;

namespace PizzaBox.Testing.Tests
{
    public class ToppingTests
    {
        [Fact]
        public void Test_BaconName()
        {
            // arrange
            var sut = new Bacon();

            // act
            var actual = sut.Name;

            // assert
            Assert.Equal("Bacon", actual);
        }
        [Fact]
        public void Test_PineappleName()
        {
            // arrange
            var sut = new Pineapple();

            // act
            var actual = sut.Name;

            // assert
            Assert.Equal("Pineapple (the best toping)", actual);
        }
    }
}