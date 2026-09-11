namespace Collections.Queue
{
    /// <summary>
    /// Represents a generic Queue
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the queue.</typeparam>
    internal class GenericQueue<T>
    {
        private readonly Queue<T> _queue = new ();

        /// <summary>
        /// Adds an item to the queue.
        /// </summary>
        /// <param name="item">The object to add to the queue.</param>
        public void Enqueue(T item)
        {
            _queue.Enqueue(item);
        }

        /// <summary>
        /// Removes the item at the beginning of the queue.
        /// </summary>
        public void Dequeue()
        {
            if (_queue.Count > 0)
            {
                _queue.Dequeue();
            }
            else
            {
                Console.WriteLine("Empty Queue");
            }
        }

        /// <summary>
        /// prints all item present in the queue.
        /// </summary>
        public void DisplayAll()
        {
            foreach (T item in _queue)
            {
                Console.WriteLine(item);
            }
        }
    }
}
