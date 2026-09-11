namespace Collections
{
    /// <summary>
    /// Represents a generic stack.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the stack.</typeparam>
    internal class GenericStack<T>
    {
        private Stack<T> _stack = new ();

        /// <summary>
        /// Inserts an item to the stack.
        /// </summary>
        /// <param name="item">The object to push onto the stack.</param>
        public void Push(T item)
        {
            this._stack.Push(item);
        }

        /// <summary>
        /// Removes and returns the item at the top of the stack.
        /// </summary>
        /// <returns>The object removed from the top of the stack.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the stack is empty.</exception>
        public T Pop()
        {
            if (this._stack.Count != 0)
            {
                return this._stack.Pop();
            }
            else
            {
                throw new InvalidOperationException("No element to pop. The stack is empty.");
            }
        }

        /// <summary>
        /// Gets the total number of items currently contained in the stack.
        /// </summary>
        /// <returns>The number of elements in the stack.</returns>
        public int Count()
        {
            return this._stack.Count;
        }
    }
}
