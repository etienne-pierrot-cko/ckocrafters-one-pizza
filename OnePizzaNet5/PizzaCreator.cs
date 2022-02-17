namespace OnePizzaNet5
{
    using System.Collections.Generic;
    using System.Linq;

    public class PizzaRater
    {

        public static void RatePizza(Pizza pizza, List<Client> clients)
        {
            foreach (var client in clients)
            {
                if (client.Dislikes.Intersect(pizza.Ingredients).Any())
                {
                    continue;
                }

                if (client.Likes.Intersect(pizza.Ingredients).Count() == pizza.Ingredients.Count)
                {
                    pizza.Rating += 1;
                }
            }
        }
    }

    public class PizzaCreator
    {
        public static Pizza CreatePizzaFromClients(List<Client> clients)
        {
            return new Pizza()
            {
                Ingredients = clients.SelectMany(x => x.Likes).Distinct().ToList()
            };
        }
    }
}
