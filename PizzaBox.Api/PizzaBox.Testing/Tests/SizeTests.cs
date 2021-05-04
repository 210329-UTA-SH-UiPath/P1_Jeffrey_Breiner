using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Components;
using PizzaBox.Domain.Models.Sizes;
using Xunit;

namespace PizzaBox.Testing.Tests
{
    /// <summary>
    /// 
    /// </summary>
    public class SizeTests
    {
        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void Test_SizeName()
        {
            // arrange
            var sut = new SmallSize();

            // act
            var actual = sut.Name;

            // assert
            Assert.True(actual == "Small");
        }
        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void Test_StorePrice()
        {
            // arrange
            var sut = new SmallSize();

            // act
            var actual = sut.Price;

            // assert
            Assert.True(actual == 3m);
        }
        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void Test_SizeEnum()
        {
            // arrange
            var sut = new SmallSize();

            // act
            var actual = sut.SIZE;

            // assert
            Assert.True(actual == SIZES.SMALL);
        }
        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void Test_StoreName2()
        {
            // arrange
            var sut = new LargeSize();

            // act
            var actual = sut.Name;

            // assert
            Assert.True(actual == "Large");
        }
    }
}
