namespace Collections
{
    internal class PeopleQueue
    {
        public void ExecutePeopleQueue()
        {
            Queue<string> queue = new();
            Console.WriteLine("Adding 5 Persons ");
            queue.Enqueue("Person - 1");
            queue.Enqueue("Person - 2");
            queue.Enqueue("Person - 3");
            queue.Enqueue("Person - 4");
            queue.Enqueue("Person - 5");
            foreach(string name in queue)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("Dequeuing 3 Persons");
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            Console.WriteLine("After Dequeuing");
            foreach (string name in queue)
            {
                Console.WriteLine(name);
            }
        }
    }
}
