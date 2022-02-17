namespace OnePizzaNet5;

using System;
using System.Collections.Generic;
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
        var p = HashCode.Combine(obj.Ingredients.Select(y => y.GetHashCode()).ToArray());
        return p;
    }
}
