namespace OnePizza.Tests
{
    using FluentAssertions;
    using OnePizzaNet5;
    using System.Collections.Generic;
    using Xunit;

    public class PizzaRaterTests
    {
        [Fact]
        public void GivenPizzaWithOneIngredient_Returns_Null()
        {
            var pizza = new Pizza() { Ingredients = new List<string>() { "cheese", "mushrooms", "tomatoes", "peppers" } };
            var clients = new List<Client>()
            {
                new Client()
                {
                    Likes = new List<string>() { "cheese", "peppers" },
                    Dislikes = new List<string>() { },
                },
                new Client()
                {
                    Likes = new List<string>() { "basil", "egg" },
                    Dislikes = new List<string>() {"pineapple" },
                },
                new Client()
                {
                    Likes = new List<string>() { "mushrooms", "tomatoes" },
                    Dislikes = new List<string>() {"basil" },
                },
            };
            PizzaRater.RatePizza(pizza, clients);
            pizza.Rating.Should().Be(2);
        }
    }
}
