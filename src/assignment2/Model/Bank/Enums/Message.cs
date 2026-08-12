namespace ManagementSystem.Model.Bank.Enums
{
    /// <summary>
    /// enum to return the messages
    /// </summary>
    internal enum Message
    {
        /// <summary>
        /// if the balance is insufficient
        /// </summary>
        InsufficientBalance,

        /// <summary>
        /// if minimum balance requirement is not met
        /// </summary>
        MinimumBalance,

        /// <summary>
        /// the withdraw is successful
        /// </summary>
        Successful,
    }
}
