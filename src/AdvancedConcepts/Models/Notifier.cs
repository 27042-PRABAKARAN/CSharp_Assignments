namespace AdvancedConcepts.Models
{
    /// <summary>
    /// Acts as an event publisher that broadcasts notification messages to subscribers.
    /// </summary>
    internal class Notifier
    {
        /// <summary>
        /// Defines a delegate structure for handling text-based notifications.
        /// </summary>
        /// <param name="message">The notification message text to broadcast.</param>
        internal delegate void Notify(string message);

        /// <summary>
        /// Occurs when an action is executed and a notification message needs to be sent to subscribers.
        /// </summary>
        internal event Notify? OnAction;

        /// <summary>
        /// Triggers the event and broadcasts the specified notification message to all registered subscribers.
        /// </summary>
        /// <param name="message">The message to pass along to event subscribers.</param>
        internal void Execute(string message)
        {
            this.OnAction?.Invoke(message);
        }
    }
}
