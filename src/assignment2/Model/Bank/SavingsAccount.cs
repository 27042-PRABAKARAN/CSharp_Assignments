namespace ManagementSystem.Model.Bank
{
    /// <summary>
    /// Savings
    /// </summary>
    internal class SavingsAccount : BankAccount
    {
        /// <summary>
        /// MinBalance stores the minimum balance to be maintained .
        /// </summary>
        public const decimal MinBalance = 5000;

        /// <summary>
        /// Initializes a new instance of the <see cref="SavingsAccount"/> class.
        /// </summary>
        /// <param name="accountNumber"> the account number of the account</param>
        /// <param name="balance"> the balance </param>
        public SavingsAccount(string accountNumber, decimal balance)
        {
            this.AccountNumber = accountNumber;
            this.Balance = balance;
        }

        /// <summary>
        /// overriding to string to print details
        /// </summary>
        /// <returns> returns details</returns>
        public override string ToString()
        {
            return $"This is a Savings Account.\nAccount Number is {this.AccountNumber}.\nThe Balance is {this.Balance} Rupees.";
        }
    }
}
