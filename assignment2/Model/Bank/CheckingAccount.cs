using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public CheckingAccount(string? accountNumber, double balance)
        {
            this.AccountNumber = accountNumber;
            this.Balance = balance;
        }

        /// <summary>
        /// withdraws the amount from account.
        /// </summary>
        /// <param name="amount"> the amount to be withdrawed </param>
        public override void Withdraw(double amount)
        {
         this.Balance -= amount;
        }
    }
}
