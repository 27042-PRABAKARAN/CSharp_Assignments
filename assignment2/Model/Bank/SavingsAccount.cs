using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Model.Bank
{
    /// <summary>
    /// Savings
    /// </summary>
    internal class SavingsAccount : BankAccount
    {
        /// <summary>
        /// MinBalance stores the minimum balance to be maintained .
        /// </summary>
        private static decimal _minBalance = 5000;

        /// <summary>
        /// Initializes a new instance of the <see cref="SavingsAccount"/> class.
        /// </summary>
        /// <param name="accountNumber"> the account number of the account</param>
        /// <param name="balance"> the balance </param>
        public SavingsAccount(string? accountNumber, decimal? balance)
        {
            this.AccountNumber = accountNumber;
            this.Balance = balance;
        }

        /// <summary>
        /// withdraws the amount from account.
        /// </summary>
        /// <param name="amount"> the amount to be withdrawed </param>
        /// <returns> returns boolean of the withdraw </returns>
        public override bool Withdraw(decimal? amount)
        {
            if (this.Balance - amount >= MinBalance)
            {
                this.Balance -= amount;
                return true;
            }

            return false;
        }
    }
}
