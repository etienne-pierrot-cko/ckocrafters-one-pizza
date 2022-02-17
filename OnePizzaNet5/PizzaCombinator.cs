namespace OnePizzaNet5
{
    using System.Collections.Generic;

    public static class PizzaCombinator
    {
        public static List<Pizza> AllPizzasFromBestPizzaMinusOneIngredient(Pizza pizza)
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
