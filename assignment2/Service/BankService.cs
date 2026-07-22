using Assignment2.Model.Bank;

namespace Assignment2.Service
{
    /// <summary>
    /// the bank services takes place here
    /// </summary>
    internal class BankService
    {
        /// <summary>
        /// accounts
        /// </summary>
        private static long _accounts = 1000000000;

        /// <summary>
        /// creates savings account.
        /// </summary>
        /// <param name="capital"> the capital when account is created </param>
        /// <returns> returns the message </returns>
        public string? CreateSavingAccount(long capital)
        {
            SavingsAccount newAccount = new SavingsAccount(_accounts++.ToString(), capital);
            return "Created Succesfully";
        }

        /// <summary>
        /// creates Checking account.
        /// </summary>
        /// <param name="capital"> the capital when account is created </param>
        /// <returns> returns the message </returns>
        public BankAccount CreateCheckingAccount(long capital)
        {
            CheckingAccount newAccount = new CheckingAccount(_accounts++.ToString(), capital);
            return newAccount;
        }

        /// <summary>
        /// to deposit amount
        /// </summary>
        /// <param name="account"> the account which deposit should be made </param>
        /// <param name="amount"> the amount to be deposited </param>
        public void Deposit(BankAccount account, double amount)
        {
            account.DepositAmount(amount);
        }

        /// <summary>
        /// to Withdraw amount
        /// </summary>
        /// <param name="account"> the account which WithDraw should be made </param>
        /// <param name="amount"> the amount to be Withdrawed </param>
        /// <returns> returns the status </returns>
        public bool WithDraw(BankAccount account, double amount)
        {
            if (account.Balance < amount)
            {
                return false;
            }

            account.Withdraw(amount);
            return true;
        }
    }
}
