namespace Collections
{
    /// <summary>
    /// Represents a generic Queue
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the queue.</typeparam>
    internal class GenericQueue<T>
    {
        private readonly Queue<T> _queue = new Queue<T>();

        /// <summary>
        /// Adds an item to the queue.
        /// </summary>
        /// <param name="item">The object to add to the queue.</param>
        public void Enqueue(T item)
        {
            this._queue.Enqueue(item);
        }

        /// <summary>
        /// Removes the item at the beginning of the queue.
        /// </summary>
        public void Dequeue()
        {
            if (this._queue.Count > 0)
            {
                this._queue.Dequeue();
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
            foreach (T item in this._queue)
            {
                Console.WriteLine(item);
            }
        }
    }
}
