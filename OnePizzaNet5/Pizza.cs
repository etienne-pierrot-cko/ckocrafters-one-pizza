using System.Collections.Generic;

namespace OnePizzaNet5
{
    using System;

    public class Pizza
    {
        public HashSet<string> Ingredients { get; set; } = new();

        public int Rating { get; set; }
    }
}
