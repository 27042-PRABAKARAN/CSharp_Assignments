namespace Assignment2.Model
{
    /// <summary>
    /// the Bank Account Class
    /// </summary>
    internal class BankAccount
    {
        /// <summary>
        /// gets or sets the account number of the bank account
        /// </summary>
        /// <value>
        /// the account number of the bank account
        /// </value>
        public string? AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the balance in the bank account
        /// </summary>
        /// <value>
        /// the account number of the bank account
        /// </value>
        public double Balance { get; set; }

        /// <summary>
        /// the amount to be deposited will be added in the balance
        /// </summary>
        /// <param name="amount"> the amount to be deposited </param>
        public void DepositAmount(double amount)
        {
            this.Balance += amount;
        }

        /// <summary>
        /// this method
        /// </summary>
        /// <param name="amount"> the amount to be withdrawn </param>
        public virtual void Withdraw(double amount)
        {
            this.Balance -= amount;
        }
    }
}
