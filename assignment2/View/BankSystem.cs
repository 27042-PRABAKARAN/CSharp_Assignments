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
            /// to withdraw amount
            /// </summary>
            WithDraw,

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
            Output.Display("Welcome to Account Management System :  ");
            while (true)
            {
                Output.Display("1. Create A Saving Account.\n2. Create A Checking Account.\n3. Exit the app");
                string? userInput = UserInput.ReadInput("Enter the choice: ");
                int index;
                int.TryParse(userInput, out index);
                Operation operation = (Operation)index;
                BankAccount? account = null;
                switch (operation)
                {
                    case Operation.CreateSavings: account = this.CreateSavingAccount(); break;
                    case Operation.CreateChecking: account = this.CreateCheckingAccount(); break;
                    case Operation.WithDraw: this.Withdraw(account); break;
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
            decimal? amount = UserInput.ReadAmount("Enter the capital of the account: ");
            if (amount == null)
            {
                return null;
            }

            return this._bankServices.CreateSavingAccount(amount);
        }

        /// <summary>
        /// creates Developer
        /// </summary>
        /// <returns> returns the created bank account </returns>
        public BankAccount? CreateCheckingAccount()
        {
            decimal? amount = UserInput.ReadAmount("Enter the capital of the account: ");
            if (amount == null)
            {
                return null;
            }

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

            decimal? amount = UserInput.ReadAmount("Enter the amount to be deposited: ");
            if (amount == null)
            {
                return;
            }

            this._bankServices.WithDraw(account, amount);
        }
    }
}
