namespace OnePizzaNet5
{
    using System.Collections.Generic;
    using System.Linq;

    public class PizzaCreator
    {
        public static Pizza CreatePizzaFromClients(List<Client> clients)
        {
            var hash = new HashSet<string>();
            foreach (var like in clients.SelectMany(client => client.Likes))
            {
                hash.Add(like);
            }

            return new Pizza()
            {
                Ingredients = hash.ToList()
            };
        }
    }
}
