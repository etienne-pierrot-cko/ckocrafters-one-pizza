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

                if (client.Likes.Intersect(pizza.Ingredients).Count() == client.Likes.Count)
                {
                    pizza.Rating += 1;
                }
            }
        }
    }
}
