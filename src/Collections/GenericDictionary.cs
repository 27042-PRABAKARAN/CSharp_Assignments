namespace Collections
{
    /// <summary>
    /// A generic wrapper class for managing dictionary.
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
    internal class GenericDictionary<TKey, TValue>
        where TKey : notnull
    {
        private Dictionary<TKey, TValue> _dictionary = new ();

        /// <summary>
        /// Adds a key and its value to the dictionary.
        /// </summary>
        /// <param name="key">The key of the element to add.</param>
        /// <param name="value">The value of the element to add.</param>
        public void Add(TKey key, TValue value)
        {
            this._dictionary.Add(key, value);
        }

        /// <summary>
        /// Removes an item from the dictionary using its key.
        /// </summary>
        /// <param name="key">The key of the element to remove.</param>
        /// <returns>True if the item was found and removed; otherwise, false.</returns>
        public bool Remove(TKey key)
        {
            return this._dictionary.Remove(key);
        }

        /// <summary>
        /// Displays all keys and their corresponding values in the console.
        /// </summary>
        public void DisplayAll()
        {
            foreach (TKey name in this._dictionary.Keys)
            {
                Console.WriteLine($"{name} : {this._dictionary[name]}");
            }
        }
    }
}
