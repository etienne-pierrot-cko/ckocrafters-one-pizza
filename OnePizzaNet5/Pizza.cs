using System.Collections.Generic;

namespace OnePizzaNet5
{
    using System;
    using System.Linq;

    public class PizzaComparer : IEqualityComparer<Pizza>
    {
        public bool Equals(Pizza x, Pizza y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (ReferenceEquals(x, null))
            {
                return false;
            }

            if (ReferenceEquals(y, null))
            {
                return false;
            }

            if (x.GetType() != y.GetType())
            {
                return false;
            }

            return x.Ingredients.Intersect(y.Ingredients).Count() == x.Ingredients.Count;
        }

        public int GetHashCode(Pizza obj)
        {
            return HashCode.Combine(obj.Ingredients, obj.Rating);
        }
    }

    public class Pizza : IEquatable<Pizza>
    {
        public List<string> Ingredients { get; set; } = new();

        public int Rating { get; set; }

        public bool Equals(Pizza other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Ingredients.Intersect(other.Ingredients).Count() == Ingredients.Count;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((Pizza) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Ingredients, Rating);
        }
    }
}
