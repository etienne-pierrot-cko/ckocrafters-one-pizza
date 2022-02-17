using OnePizza;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

static List<Client> Parse(string[] args)
{
    throw new NotImplementedException();
}

static Pizza FindBestPizza(List<Client> clients)
{
    throw new NotImplementedException();
}


var clients = Parse(args);
var pizza = FindBestPizza(clients);
PizzaDumper.DumpBestPizzaToFile(pizza);

