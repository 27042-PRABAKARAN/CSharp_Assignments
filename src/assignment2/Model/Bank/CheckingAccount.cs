namespace ManagementSystem.Model.Bank
{
    /// <summary>
    /// Checking account inherited from BankAccount
    /// </summary>
    internal class CheckingAccount : BankAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckingAccount"/> class.
        /// </summary>
        /// <param name="accountNumber"> the account number of the account</param>
        /// <param name="balance"> the balance </param>
        public CheckingAccount(string accountNumber, decimal balance)
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
            return $"This is a Checking Account.\nAccount Number is {this.AccountNumber}.\nThe Balance is {this.Balance} Rupees.";
        }
    }
}
