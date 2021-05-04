using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Components;
using PizzaBox.Domain.Models.Crusts;
using Xunit;

namespace PizzaBox.Testing.Tests
{
    /// <summary>
    /// 
    /// </summary>
    public class CrustTests
    {
        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void Test_CrustName()
        {
            // arrange
            var sut = new ThinCrust();

            // act
            var actual = sut.Name;

            // assert
            Assert.True(actual == "Thin Crust");
        }
        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void Test_CrustPrice()
        {
            // arrange
            var sut = new StandardCrust();

            // act
            var actual = sut.Price;

            // assert
            Assert.True(actual == 1.5m);
        }
        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void Test_CrustEnum()
        {
            // arrange
            var sut = new ThinCrust();

            // act
            var actual = sut.CRUST;

            // assert
            Assert.True(actual == CRUSTS.THIN);
        }
    }
}
