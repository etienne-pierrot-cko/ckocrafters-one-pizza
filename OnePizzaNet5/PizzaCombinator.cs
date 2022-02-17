namespace OnePizzaNet5
{
    using System.Collections.Generic;

    public static class PizzaCombinator
    {
        public static HashSet<Pizza> AllPizzasFromBestPizzaMinusOneIngredient(Pizza largestPizza)
        {
            var combinations = new HashSet<Pizza>(new PizzaComparer()) { largestPizza };
            var stack = new Stack<Pizza>();
            stack.Push(largestPizza);
            while (stack.Count > 0)
            {
                var pizzas = PizzasFromPizzaMinusOneIngredient(stack.Pop());
                if (pizzas == null)
                    continue;
                foreach (Pizza pizza in pizzas)
                {
                    combinations.Add(pizza);
                }

                foreach (Pizza pizza in pizzas)
                {
                    stack.Push(pizza);
                }
            }

            return combinations;
        }

        public static List<Pizza> PizzasFromPizzaMinusOneIngredient(Pizza pizza)
        {
            if (pizza.Ingredients.Count == 1)
            {
                return null;
            }

            var pizzas = new List<Pizza>();
            for (int hide = 0; hide < pizza.Ingredients.Count; hide++)
            {
                var pizza1 = new Pizza();
                for (int i = 0; i < pizza.Ingredients.Count; i++)
                {
                    if (i != hide)
                    {
                        pizza1.Ingredients.Add(pizza.Ingredients[i]);
                    }

                }

                pizzas.Add(pizza1);
            }

            return pizzas;
        }
    }
}
