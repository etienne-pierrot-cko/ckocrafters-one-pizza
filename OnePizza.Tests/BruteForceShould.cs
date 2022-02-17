namespace OnePizza.Tests
{
    using FluentAssertions;
    using OnePizzaNet5;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class BruteForceShould
    {
        private List<Client> _clients;
        private readonly BruteForceScorer _bruteForceScorer;

        public BruteForceShould()
        {
            _clients = new List<Client>()
            {
                new()
                {
                    Likes = new List<string>()
                    {
                        "cheese",
                        "peppers"
                    }, 
                    Dislikes = new List<string>()
                },
                new()
                {
                    Likes = new List<string>()
                    {
                        "basil",
                    },
                    Dislikes = new List<string>()
                    {
                        "pineapple"
                    }
                },
                new()
                {
                    Likes = new List<string>()
                    {
                        "mushrooms",
                        "tomatoes"
                    },
                    Dislikes = new List<string>()
                    {
                        "basil"
                    }
                }
            };
            _bruteForceScorer = new BruteForceScorer();
        }
        
        [Fact]
        public void CompareList()
        {
            var l1 =  new List<string>()
            {
                "mushrooms",
                "tomatoes"
            };
            
            var l2 =  new List<string>()
            {
                "tomatoes",
                "mushrooms",
            };
            new List<List<string>>()
                {
                    l1, l2
                }
            .Distinct(ListEqualityComparer<string>.Default).ToList().Count().Should().Be(1);
         
        }

        [Fact]
        public void GiveTheBestPizza()
            => _bruteForceScorer.BruteForce(_clients).Ingredients.Should().BeEquivalentTo(new List<string>
            {
                "basil", "cheese", "mushrooms", "peppers", "tomatoes"
            });

        [Fact]
        public void Check_Pizza_With_Ingredient_Client_Didnt_Like()
        {
            BruteForceScorer.CheckClientLikePizza(new()
            {
                Likes = new List<string>()
                {
                    "mushrooms",
                    "tomatoes"
                },
                Dislikes = new List<string>() { "basil" }
            }, new List<string>() { "basil" }).Should().BeFalse();
        }
        
        [Fact]
        public void Check_Pizza_With_Ingredient_Client_Like()
        {
            BruteForceScorer.CheckClientLikePizza(new()
            {
                Likes = new List<string>()
                {
                    "mushrooms",
                    "tomatoes"
                },
                Dislikes = new List<string>() { "basil" }
            }, new List<string>() { "mushrooms", "tomatoes" }).Should().BeTrue();
        }
        
        [Fact]
        public void Check_Pizza_With_Ingredient_That_Client_Like_Missing()
        {
            BruteForceScorer.CheckClientLikePizza(new()
            {
                Likes = new List<string>()
                {
                    "mushrooms",
                    "tomatoes"
                },
                Dislikes = new List<string>() { "basil" }
            }, new List<string>() { "mushrooms" }).Should().BeFalse();
        }
        
        [Fact]
        public void Check_Pizza_With_Ingredient_Client_Like_And_Another_Didnt_Like()
        {
            BruteForceScorer.CheckClientLikePizza(new()
            {
                Likes = new List<string>()
                {
                    "mushrooms",
                    "tomatoes"
                },
                Dislikes = new List<string>() { "basil" }
            }, new List<string>() { "tomatoes", "mushrooms", "basil", "peppers", "cheese" }).Should().BeFalse();
        }
        
        [Fact]
        public void TestScore()
            => BruteForceScorer.Score(_clients, new List<string>
            {
                "cheese",
                "mushrooms",
                "tomatoes",
                "peppers"
            }).Should().Be(2);
    }
}
