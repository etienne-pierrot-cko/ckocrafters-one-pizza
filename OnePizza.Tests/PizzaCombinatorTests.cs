namespace OnePizza.Tests
{
    using FluentAssertions;
    using OnePizzaNet5;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class PizzaCombinatorTests
    {
        [Fact]
        public void GivenPizzaWithOneIngredient_Returns_Null()
        {
            var from = new Pizza() { Ingredients = new List<string>() { "pepper" } };
            var to = PizzaCombinator.AllPizzasFromBestPizzaMinusOneIngredient(from);
            to.Should().BeNull();
        }


        [Fact]
        public void GivenPizzaWithTwoIngredients_ReturnsTwoPizzas()
        {
            var from = new Pizza() { Ingredients = new List<string>() { "pepper", "egg" } };
            var to = PizzaCombinator.AllPizzasFromBestPizzaMinusOneIngredient(from);
            var expected = from.Ingredients.Select(x => new Pizza() { Ingredients = new List<string>() { x } }).ToList();
            to.Should().BeEquivalentTo(expected);
        }


        [Fact]
        public void GivenPizzaWithThreeIngredients_ReturnsTwoPizzas()
        {
            var from = new Pizza() { Ingredients = new List<string>() { "pepper", "egg", "cheese" } };
            var to = PizzaCombinator.AllPizzasFromBestPizzaMinusOneIngredient(from);
            var p1 = new Pizza() { Ingredients = new List<string>() { "pepper", "egg" } };
            var p2 = new Pizza() { Ingredients = new List<string>() { "pepper", "cheese" } };
            var p3 = new Pizza() { Ingredients = new List<string>() { "egg", "cheese" } };
            var expected = new List<Pizza>() { p1, p2, p3 };
            to.Should().BeEquivalentTo(expected);
        }
    }
}
