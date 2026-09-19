namespace AdvancedConcepts.Tasks
{
    internal class Events
    {
        public void ExecuteEvent()
        {
            Notifier notifier = new Notifier();
            notifier.OnAction += this.PrintMessage;
            notifier.Execute("This statement is printed in the console");
        }

        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
