namespace OnePizzaNet5
{
    using System;
    using System.Collections.Generic;

    public class Client
    {
        public Guid Id { get; set; } = Guid.NewGuid();

    
        public List<string> Likes { get; set; }
    
        public List<string> Dislikes { get; set; }
    }
}
