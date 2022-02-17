namespace OnePizzaNet5
{
    using System.Collections.Generic;
    using System.Linq;

    public class BruteForceScorer
    {
        public Pizza BruteForce(List<Client> clients)
        {
            var allIngredients  = clients
                .Select(c => c.Dislikes.Concat(c.Likes))
                .SelectMany(x => x).Distinct()
                .ToList();

            //TODO filtering duplicate combinations
            var combinations = Enumerable.Distinct(GetAllCombos(allIngredients), ListEqualityComparer<string>.Default).ToList();
            
            IEnumerable<IOrderedEnumerable<string>> enumerable = combinations.Select(x => x.OrderBy(i => i)).Distinct();
            var a = combinations.Select<List<string>, (List<string> c, int)>(c => (c, Score(clients, c)));
            List<string> bestCombination = a.OrderBy(x => x.Item2).Last().c;
            return new Pizza()
            {
                Ingredients = bestCombination
            };
        }

        public static bool CheckClientLikePizza( Client client, List<string> ingredients)
        {
            bool dislikeOneIngredient  = ingredients.Select(i => client.Dislikes.Contains(i)).Count(x => x) > 0;
            bool allLikeIngredient = client.Likes.Select(ingredients.Contains).All(x => x);
            return !dislikeOneIngredient && allLikeIngredient;
        }

        public static int Score(List<Client> clients, List<string> ingredients)
            => clients.Count(c => CheckClientLikePizza(c, ingredients));

        private static List<List<string>> GetAllCombos(List<string> list)
        {
            List<List<string>> result = new();
            // head
            result.Add(new List<string>());
            result.Last().Add(list[0]);
            if (list.Count == 1)
                return result;
            // tail
            List<List<string>> tailCombos = GetAllCombos(list.Skip(1).ToList());
            tailCombos.ForEach(combo =>
            {
                result.Add(new List<string>(combo.OrderBy(x => x)));
                combo.Add(list[0]);
                result.Add(new List<string>(combo.OrderBy(x => x)));
            });
            return result;
        }
    }
}
