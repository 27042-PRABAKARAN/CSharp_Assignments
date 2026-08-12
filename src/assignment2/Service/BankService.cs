using ManagementSystem.Model.Bank;
using ManagementSystem.Model.Bank.Enums;

namespace ManagementSystem.Service
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
        public BankAccount CreateSavingAccount(decimal capital)
        {
            SavingsAccount newAccount = new SavingsAccount((++_accounts).ToString(), capital);
            return newAccount;
        }

        /// <summary>
        /// creates Checking account.
        /// </summary>
        /// <param name="capital"> the capital when account is created </param>
        /// <returns> returns the message </returns>
        public BankAccount CreateCheckingAccount(decimal capital)
        {
            CheckingAccount newAccount = new CheckingAccount((++_accounts).ToString(), capital);
            return newAccount;
        }

        /// <summary>
        /// to deposit amount
        /// </summary>
        /// <param name="account"> the account which deposit should be made </param>
        /// <param name="amount"> the amount to be deposited </param>
        public void Deposit(BankAccount account, decimal amount)
        {
            account.DepositAmount(amount);
        }

        /// <summary>
        /// to Withdraw amount
        /// </summary>
        /// <param name="account"> the account which WithDraw should be made </param>
        /// <param name="amount"> the amount to Withdraw </param>
        /// <returns> returns the status </returns>
        public Message WithDraw(BankAccount account, decimal amount)
        {
            if (account is SavingsAccount)
            {
                if (account.Balance < amount)
                {
                    return Message.InsufficientBalance;
                }

                if (account.Balance - amount < SavingsAccount.MinBalance)
                {
                    return Message.MinimumBalance;
                }

                account.Withdraw(amount);
                return Message.Successful;
            }
            else
            {
                if (account.Balance - amount < 0)
                {
                    return Message.InsufficientBalance;
                }

                account.Withdraw(amount);
                return Message.Successful;
            }
        }

        /// <summary>
        /// this fetches Details
        /// </summary>
        /// <param name="account"> from which account the balance to be fetched </param>
        /// <returns> details </returns>
        public string FetchDetails(BankAccount account)
        {
            return account.ToString();
        }
    }
}
