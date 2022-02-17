namespace OnePizzaNet5
{
    using System.IO;
    using System.Linq;

    public class PizzaDumper
    {
        public static void DumpBestPizzaToFile(Pizza pizza)
        {
            var ingredientConcatened = pizza.Ingredients.Aggregate("", (ingredient1, ingredient2) => ingredient1 + " " + ingredient2);
            File.WriteAllText("output.txt", $"{pizza.Ingredients.Count}{ingredientConcatened}");
        }
    }
}
