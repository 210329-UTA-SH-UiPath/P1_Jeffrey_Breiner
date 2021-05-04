using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models.Components;
using PizzaBox.Domain.Models.Crusts;
using PizzaBox.Domain.Models.Pizzas;
using PizzaBox.Storing.Entities.EntityModels;
using PizzaBox.Storing.Mappers;
using Xunit;

namespace PizzaBox.Testing.Tests
{
    public class MappingTests
    {

        [Fact]
        public void Test_CrustMapping()
        {
            // arrange
            MapperCrust mapperCrust = new MapperCrust();
            var sut = new DBCrust();
            sut.CRUST = CRUSTS.DEEPDISH;

            // act
            var sut2 = mapperCrust.Map(sut);
            var actual = sut2;

            // assert
            Assert.True(actual.CRUST != CRUSTS.THIN);
        }

        [Fact]
        public void Test_ToppingMapping()
        {
            // arrange
            MapperTopping mapperTopping = new MapperTopping();
            var sut = new DBTopping();
            sut.TOPPING = TOPPINGS.BACON;

            // act
            var sut2 = mapperTopping.Map(sut);
            var actual = sut2;

            // assert
            Assert.True(actual.TOPPING == TOPPINGS.BACON);
        }

        [Fact]
        public void Test_StoreMapping()
        {
            // arrange
            MapperStore mapperStore = new MapperStore();
            var sut = new DBStore();
            sut.STORE = STORES.NEWYORK;

            // act
            var sut2 = mapperStore.Map(sut);
            var actual = sut2;

            // assert
            Assert.True(actual.STORE == STORES.NEWYORK);
        }
    }
}