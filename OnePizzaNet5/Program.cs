using System;

namespace OnePizzaNet5
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    internal class Program
    {
        static void Main(string[] args)
        {
            var clients = Parse(args);
            var pizza = FindBestPizza(clients);
            PizzaDumper.DumpBestPizzaToFile(pizza);
            Console.WriteLine(JsonSerializer.Serialize(pizza));
        }


        static List<Client> Parse(string[] args) =>
            FileReader.Get(args[0]);

        static Pizza FindBestPizza(List<Client> clients)
        {
            var firstPizza = PizzaCreator.CreatePizzaFromClients(clients);
            return GetBestPizzaFromAllCombinations(firstPizza, clients);
        }

        private static Pizza GetBestPizzaFromAllCombinations(Pizza bestPizza, List<Client> clients)
        {
            var ingridientsCountStop = clients.Min(x => x.Likes.Count());
            var allCombinations = PizzaCombinator.AllPizzasFromBestPizzaMinusOneIngredient(bestPizza, ingridientsCountStop);
            foreach (Pizza pizza in allCombinations)
            {
                PizzaRater.RatePizza(pizza, clients);
            }

            return allCombinations.OrderByDescending(x => x.Rating).First();
        }
    }
}
