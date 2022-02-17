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
            var to = PizzaCombinator.PizzasFromPizzaMinusOneIngredient(from);
            to.Should().BeNull();
        }


        [Fact]
        public void GivenPizzaWithTwoIngredients_ReturnsTwoPizzas()
        {
            var from = new Pizza() { Ingredients = new List<string>() { "pepper", "egg" } };
            var to = PizzaCombinator.PizzasFromPizzaMinusOneIngredient(from);
            var expected = from.Ingredients.Select(x => new Pizza() { Ingredients = new List<string>() { x } }).ToList();
            to.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GivenPizzaWithThreeIngredients_ReturnsThreePizzas()
        {
            var from = new Pizza() { Ingredients = new List<string>() { "pepper", "egg", "cheese" } };
            var to = PizzaCombinator.PizzasFromPizzaMinusOneIngredient(from);
            var p1 = new Pizza() { Ingredients = new List<string>() { "pepper", "egg" } };
            var p2 = new Pizza() { Ingredients = new List<string>() { "pepper", "cheese" } };
            var p3 = new Pizza() { Ingredients = new List<string>() { "egg", "cheese" } };
            var expected = new List<Pizza>() { p1, p2, p3 };
            to.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GivenPizzaWithFourIngredients_ReturnsFourPizzas()
        {
            var from = new Pizza() { Ingredients = new List<string>() { "A", "B", "C", "D" } };
            var to = PizzaCombinator.PizzasFromPizzaMinusOneIngredient(from);
            var p1 = new Pizza() { Ingredients = new List<string>() { "A", "B", "C" } };
            var p2 = new Pizza() { Ingredients = new List<string>() { "A", "B", "D" } };
            var p3 = new Pizza() { Ingredients = new List<string>() { "A", "C", "D" } };
            var p4 = new Pizza() { Ingredients = new List<string>() { "B", "C", "D" } };
            var expected = new List<Pizza>() { p1, p2, p3, p4 };
            to.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GivenPizzaWithFiveIngredients_ReturnsFourPizzas()
        {
            var from = new Pizza() { Ingredients = new List<string>() { "A", "B", "C", "D", "E" } };
            var to = PizzaCombinator.PizzasFromPizzaMinusOneIngredient(from);
            var p1 = new Pizza() { Ingredients = new List<string>() { "A", "B", "C", "D" } };
            var p2 = new Pizza() { Ingredients = new List<string>() { "A", "B", "C", "E" } };
            var p3 = new Pizza() { Ingredients = new List<string>() { "A", "B", "D", "E" } };
            var p4 = new Pizza() { Ingredients = new List<string>() { "A", "C", "D", "E" } };
            var p5 = new Pizza() { Ingredients = new List<string>() { "B", "C", "D", "E" } };
            var expected = new List<Pizza>() { p1, p2, p3, p4, p5 };
            to.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void GivenAllIngredients_ReturnsAllTheCombinationsPizzas()
        {
            var from = new Pizza() { Ingredients = new List<string>() { "pepper", "egg", "cheese" } };
            var to = PizzaCombinator.AllPizzasFromBestPizzaMinusOneIngredient(from);
            var p1 = new Pizza() { Ingredients = new List<string>() { "pepper", "egg" } };
            var p2 = new Pizza() { Ingredients = new List<string>() { "pepper", "cheese" } };
            var p3 = new Pizza() { Ingredients = new List<string>() { "egg", "cheese" } };
            var p4 = new Pizza() { Ingredients = new List<string>() { "egg" } };
            var p5 = new Pizza() { Ingredients = new List<string>() { "cheese" } };
            var p6 = new Pizza() { Ingredients = new List<string>() { "pepper" } };
            var expected = new HashSet<Pizza>() { from, p1, p2, p3, p4, p5, p6 };
            to.Should().BeEquivalentTo(expected);
        }
    }
}
