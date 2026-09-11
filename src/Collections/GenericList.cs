using System.Data.SqlTypes;

namespace Collections
{
    /// <summary>
    /// Represents a generic wrapper around List
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    internal class GenericList<T>
        where T : class
    {
        private readonly List<T> _list = new ();

        /// <summary>
        /// Adds an item to the list.
        /// </summary>
        /// <param name="item">The object to be added to the list..</param>
        public void Add(T item)
        {
            this._list.Add(item);
        }

        /// <summary>
        /// Removes the specific object from the list.
        /// </summary>
        /// <param name="item">The object to be removed from the list.</param>
        public void Remove(T item)
        {
            this._list.Remove(item);
        }

        /// <summary>
        /// To display all items in list
        /// </summary>
        public void DisplayAll()
        {
            foreach (T item in this._list)
            {
                Console.WriteLine(item?.ToString());
            }
        }

        /// <summary>
        /// Filters the list to find all items that match a specific condition.
        /// </summary>
        /// <param name="item">Item to find in list</param>
        /// <returns>A new <see cref="List{T}"/> containing elements that has been found.</returns>
        public List<T> Find(T item)
        {
            return this._list.FindAll(record => record != null && ((dynamic)record).Contains(item));
        }
    }
}
