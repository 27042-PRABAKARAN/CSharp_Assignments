using AdvancedConcepts.Models;

namespace AdvancedConcepts.Tasks
{
    /// <summary>
    /// Demonstrates how to publish and subscribe to simple events in C#.
    /// </summary>
    internal class Events
    {
        /// <summary>
        /// Executes the event demonstration by creating a publisher, subscribing a method to its event, and triggering the action.
        /// </summary>
        public void ExecuteEvent()
        {
            Notifier notifier = new Notifier();
            notifier.OnAction += this.PrintMessage;
            notifier.Execute("This statement is printed in the console");
        }

        /// <summary>
        /// Handles the raised event by printing the received notification message to the console.
        /// </summary>
        /// <param name="message">The text message passed by the event publisher.</param>
        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
