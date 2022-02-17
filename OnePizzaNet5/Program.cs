using System;

namespace OnePizzaNet5
{
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            var clients = Parse(args);
            var pizza = FindBestPizza(clients);
            PizzaDumper.DumpBestPizzaToFile(pizza);
        }


        static List<Client> Parse(string[] args) =>
            FileReader.Get(args[0]);

        static Pizza FindBestPizza(List<Client> clients)
        {
            var bestPizza = PizzaCreator.CreatePizzaFromClients(clients);
            PizzaRater.RatePizza(bestPizza, clients);
            bestPizza = DoMagic(bestPizza);
            return bestPizza;
        }

        private static Pizza DoMagic(Pizza bestPizza)
        {
            throw new NotImplementedException();
        }

        private static Pizza CreatePizzaFromClients(List<Client> clients)
        {
            return new Pizza()
            {
                Ingredients = clients.SelectMany(x => x.Likes).Distinct().ToList()
            };
        }
    }
}
