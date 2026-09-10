namespace ManagementSystem.Model.Bank
{
    /// <summary>
    /// the Bank Account Class
    /// </summary>
    internal class BankAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount"/> class.
        /// </summary>
        /// <param name="accountNumber"> account number</param>
        /// <param name="balance">the balance</param>
        public BankAccount(string accountNumber, decimal balance)
        {
            this.AccountNumber = accountNumber;
            this.Balance = balance;
        }

        /// <summary>
        /// gets or sets the account number of the bank account
        /// </summary>
        /// <value>
        /// the account number of the bank account
        /// </value>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the balance in the bank account
        /// </summary>
        /// <value>
        /// the account number of the bank account
        /// </value>
        public decimal Balance { get; set; }

        /// <summary>
        /// the amount to be deposited will be added in the balance
        /// </summary>
        /// <param name="amount"> the amount to be deposited </param>
        public void DepositAmount(decimal amount)
        {
            this.Balance += amount;
        }

        /// <summary>
        /// this method
        /// </summary>
        /// <param name="amount"> the amount to be withdrawn </param>
        /// <returns> returns the boolean</returns>
        public virtual bool Withdraw(decimal amount)
        {
            this.Balance -= amount;
            return true;
        }

        /// <summary>
        /// overriding to string to print details
        /// </summary>
        /// <returns> returns details</returns>
        public override string ToString()
        {
            return $@"Account Number is {this.AccountNumber}.
The Balance is {this.Balance} Rupees.";
        }
    }
}
