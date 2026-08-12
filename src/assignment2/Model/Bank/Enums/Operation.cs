namespace ManagementSystem.Model.Bank.Enums
{
    /// <summary>
    /// Operation enumerator
    /// </summary>
    internal enum Operation
    {
        /// <summary>
        /// to withdraw amount.
        /// </summary>
        WithDraw = 1,

        /// <summary>
        /// to deposit the amount.
        /// </summary>
        Deposit,

        /// <summary>
        /// to fetch details.
        /// </summary>
        FetchDetails,

        /// <summary>
        /// to exit the app
        /// </summary>
        Exit,
    }
}
