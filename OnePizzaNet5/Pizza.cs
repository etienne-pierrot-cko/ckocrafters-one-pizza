using System.Collections.Generic;

namespace OnePizzaNet5
{
    using System;

    public class Pizza
    {
        public List<string> Ingredients { get; set; } = new();

        public int Rate { get; set; }
    }
}
