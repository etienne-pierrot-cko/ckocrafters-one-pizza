namespace OnePizzaNet5
{
    using System.Collections.Generic;
    using System.Linq;

    public class ListEqualityComparer<T> : IEqualityComparer<List<T>>
    {
        private readonly IEqualityComparer<T> _itemEqualityComparer;

        public ListEqualityComparer() : this(null) { }

        public ListEqualityComparer(IEqualityComparer<T> itemEqualityComparer)
        {
            _itemEqualityComparer = itemEqualityComparer;
        }

        public static readonly ListEqualityComparer<T> Default = new ListEqualityComparer<T>();

        public bool Equals(List<T> x, List<T> y)
        {
            if (ReferenceEquals(x, y)) return true;
            return x.Count == y.Count && x.OrderBy(i => i).SequenceEqual(y.OrderBy(i => i));;
        }

        public int GetHashCode(List<T> list)
        {
            int hash = 17;
            foreach (var itemHash in list.Select(x => 0)
                .OrderBy(h => h))
            {
                hash += 31 * itemHash;
            }
            return hash;
        }
    }
}