namespace Collections.Queue
{
    /// <summary>
    /// Demonstrates the usage of a generic queue.
    /// </summary>
    internal class PeopleQueue
    {
        /// <summary>
        /// Enqueues peoples into a generic queue, displays them, dequeues people, and shows the updated queue.
        /// </summary>
        public void ExecutePeopleQueue()
        {
            GenericQueue<string> queue = new ();
            Console.WriteLine("Adding 5 Persons ");
            queue.Enqueue("Person - 1");
            queue.Enqueue("Person - 2");
            queue.Enqueue("Person - 3");
            queue.Enqueue("Person - 4");
            queue.Enqueue("Person - 5");
            queue.DisplayAll();
            Console.WriteLine("Dequeuing 3 Persons");
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            Console.WriteLine("After Dequeuing");
            queue.DisplayAll();
        }
    }
}
