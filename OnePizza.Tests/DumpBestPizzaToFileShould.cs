namespace OnePizza.Tests
{
    using System.Collections.Generic;
    using Xunit;
    using FluentAssertions;
    using OnePizzaNet5;
    using System.IO;

    public class DumpBestPizzaToFileShould
    {
        [Fact]
        public void WritePizzaToFile()
        {
            Pizza pizza = new()
            {
                Ingredients = new List<string>
                {
                    "cheese",
                    "mushrooms",
                    "tomatoes",
                    "peppers"
                }
            };

            PizzaDumper.DumpBestPizzaToFile(pizza);

            File.ReadAllText("output.txt").Should().Be("4 cheese mushrooms tomatoes peppers");
        }
    }
}
