using System;

namespace Examination.Src
{
    /// <summary>
    /// Generic repository with constraints.
    /// Items must implement ICloneable and IComparable<T>.
    /// </summary>
    public class Repository<T> where T : ICloneable, IComparable<T>
    {
        private List<T> _items;

        public int Count => _items.Count;

        public Repository()
        {
            _items = new List<T>();
        }

        /// <summary>
        /// Adds an item to the repository.
        /// </summary>
        public void Add(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _items.Add(item);
        }

        /// <summary>
        /// Removes an item from the repository.
        /// </summary>
        public bool Remove(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            return _items.Remove(item);
        }

        /// <summary>
        /// Sorts all items in the repository.
        /// </summary>
        public void Sort()
        {
            _items.Sort();
        }

        /// <summary>
        /// Returns all items as a list.
        /// </summary>
        public List<T> GetAll()
        {
            return new List<T>(_items);
        }

        /// <summary>
        /// Gets an item by index.
        /// </summary>
        public T this[int index]
        {
            get => _items[index];
            set => _items[index] = value;
        }

        public override string ToString()
        {
            return $"Repository<{typeof(T).Name}> with {_items.Count} item(s)";
        }
    }

    public class Point : ICloneable, IComparable<Point>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public object Clone()
        {
            return new Point() { X = X, Y = Y };
        }

        public int CompareTo(Point other)
        {
            if (other is null) return 1;
            int compare = X.CompareTo(other.X);

            if (compare != 0)
                return compare;

            return Y.CompareTo(other.Y);
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}