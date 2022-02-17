using System;

namespace OnePizzaNet5
{
    using System.Collections.Generic;

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
            throw new NotImplementedException();
        }



    }
}
