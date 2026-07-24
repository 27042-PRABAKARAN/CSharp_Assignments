using Assignment2.Helper;
using Assignment2.Model.Bank;
using Assignment2.Service;

namespace Assignment2.View
{
    /// <summary>
    /// the View class of Employee
    /// </summary>
    internal class BankSystem
    {
        /// <summary>
        /// instance of the _shapeService
        /// </summary>
        private readonly BankService _bankServices = new BankService();

        /// <summary>
        /// Operation enumerator
        /// </summary>
        internal enum Operation
        {
            /// <summary>
            /// to create a Savings account
            /// </summary>
            CreateSavings = 1,

            /// <summary>
            /// to create a Checking account
            /// </summary>
            CreateChecking,

            /// <summary>
            /// to withdraw amount.
            /// </summary>
            WithDraw,

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

        /// <summary>
        /// Function that starts the app
        /// </summary>
        public void BankOperations()
        {
            Output.Display("Hey User,\nWelcome to Account Management System :  ");
            BankAccount? account = null;
            while (true)
            {
                Output.Display("\n==========Menu==========\n1. Create A Saving Account.\n2. Create A Checking Account.\n3. Withdraw Money.\n4. Deposit Money.\n5. Get Balance.\n6. Exit the app.\n========================\n");
                int? index = UserInput.ReadInt("Enter the choice: ", 1, 6);
                if (index == null)
                {
                    Output.Display("reteurning to mainmenu");
                    return;
                }

                Operation operation = (Operation)index;
                switch (operation)
                {
                    case Operation.CreateSavings: account = this.CreateSavingAccount(); break;
                    case Operation.CreateChecking: account = this.CreateCheckingAccount(); break;
                    case Operation.WithDraw: this.Withdraw(account); break;
                    case Operation.Deposit: this.Deposit(account); break;
                    case Operation.FetchDetails:  this.FetchDetails(account); break;
                    case Operation.Exit: return;

                    default: Output.Error("enter valid choice"); break;
                }
            }
        }

        /// <summary>
        /// creates manager
        /// </summary>
        /// <returns> returns the bank Account</returns>
        public BankAccount? CreateSavingAccount()
        {
            decimal? amount = UserInput.ReadAmount($"Enter the capital of the account(Minimum balance should be {SavingsAccount.}.) in Rupees: ");
            if (amount == null)
            {
                return null;
            }

            if (amount < 5000)
            {
                Output.Error("for a Savings account the minimum balance should be 5000.");
                return null;
            }
            Output.Success("Created Savings account successfully");
            return this._bankServices.CreateSavingAccount(amount);
        }

        /// <summary>
        /// creates Developer
        /// </summary>
        /// <returns> returns the created bank account </returns>
        public BankAccount? CreateCheckingAccount()
        {
            decimal? amount = UserInput.ReadAmount("Enter the capital of the account in Rupees: ");
            if (amount == null)
            {
                return null;
            }

            Output.Success("Created Checking account successfully");
            return this._bankServices.CreateCheckingAccount(amount);
        }

        /// <summary>
        /// to withdraw amount
        /// </summary>
        /// <param name="account"> the account in which withdraw takes place</param>
        public void Withdraw(BankAccount? account)
        {
            if (account == null)
            {
                Output.Error("No account to withdraw amount. create one first.");
                return;
            }

            decimal? amount = UserInput.ReadAmount("Enter the amount to be Withdrawn in Rupees: ");
            if (amount == null)
            {
                return;
            }

            if (!this._bankServices.WithDraw(account, amount))
            {
                if (account is SavingsAccount)
                {
                    Output.Error("invalid - violates minimum balance requirement.");
                    Output.Display("Back to Menu");
                }
                else
                {
                    Output.Error("Amount entered is more than balance ");
                    Output.Display("Back to Menu");
                }
            }
            else
            {
                Output.Success("withdraw successful");
                this.FetchDetails(account);
            }
        }

        /// <summary>
        /// to deposit amount
        /// </summary>
        /// <param name="account"> the account in which deposit takes place</param>
        public void Deposit(BankAccount? account)
        {
            if (account == null)
            {
                Output.Error("No account to Deposit amount. create one first.");
                return;
            }

            decimal? amount = UserInput.ReadAmount("Enter the amount to be deposited in Rupees: ");
            if (amount == null)
            {
                return;
            }

            this._bankServices.Deposit(account, amount);
            Output.Success("Deposit Successfull");
        }

        /// <summary>
        /// this fetches details of the account.
        /// </summary>
        /// <param name="account"> account to fetch balance</param>
        public void FetchDetails(BankAccount? account)
        {
            if (account == null)
            {
                Output.Error("No account to fetch amount. create one first.");
                return;
            }
            else
            {
                Output.Display($"Account Number : {this._bankServices.FetchAccount(account).ToString()}\nAvailable balance : {this._bankServices.FetchBalance(account).ToString()} Rupees");
            }
        }
    }
}
