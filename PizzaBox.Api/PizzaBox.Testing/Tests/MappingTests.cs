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
            var sut = new DeepDishCrust();

            // act
            //var sut2 = mapperCrust.Map(sut);
            //var actual = sut2.CRUST;

            // assert
            //Assert.True(actual == CRUSTS.DEEPDISH);
        }

        [Fact]
        public void Test_PizzaMapping()
        {
            // arrange
            MapperPizza mapperPizza = new MapperPizza();
            var sut = new MeatPizza();

            // act
            //var sut2 = mapperPizza.Map(sut);
            //var actual = sut2.DBSize.Price;

            // assert
            //Assert.True(actual == (decimal)8m);
        }
    }
}