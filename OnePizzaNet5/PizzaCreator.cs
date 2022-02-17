namespace OnePizzaNet5
{
    using System.Collections.Generic;
    using System.Linq;

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
