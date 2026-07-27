namespace Assignment2.Model.Bank
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
        public CheckingAccount(string? accountNumber, decimal? balance)
        {
            this.AccountNumber = accountNumber;
            this.Balance = balance;
        }

        /// <summary>
        /// withdraws the amount from account.
        /// </summary>
        /// <param name="amount"> the amount to be withdrawed </param>
        /// <returns>returns has it successfully done</returns>
        public override bool Withdraw(decimal? amount)
        {
            if (this.Balance - amount >= 0)
            {
                this.Balance -= amount;
                return true;
            }

            return false;
        }
    }
}
