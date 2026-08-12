using ManagementSystem.Helper;
using ManagementSystem.Model.Bank;
using ManagementSystem.Service;

namespace ManagementSystem.View
{
    /// <summary>
    /// the View class of Employee
    /// </summary>
    internal class BankSystem
    {
        /// <summary>
        /// instance of the _shapeService
        /// </summary>
        private readonly BankService _bankServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankSystem"/> class.
        /// </summary>
        /// <param name="bankServices"> bank service object </param>
        public BankSystem(BankService bankServices)
        {
            this._bankServices = bankServices;
        }

        /// <summary>
        /// Function that starts the app
        /// </summary>
        public void BankOperations()
        {
            Console.WriteLine("\nWelcome to Account Management System");
            BankAccount? account = null;
            bool state = true;
            while (state)
            {
                Console.WriteLine(@"==========Menu==========
1. Create A Saving Account.
2. Create A Checking Account.
3. Exit the app.
========================");
                int? index = UserInput.ReadInt("Enter the choice: ", 1, 3);
                if (index == null)
                {
                    Console.WriteLine("returning to main menu");
                    return;
                }

                AccountType accountType = (AccountType)index;
                switch (accountType)
                {
                    case AccountType.CreateSavings: account = this.CreateSavingAccount(); break;
                    case AccountType.CreateChecking: account = this.CreateCheckingAccount(); break;
                    case AccountType.Exit: state = false; break;

                    default: Output.Error("enter valid choice"); break;
                }

                if (account == null)
                {
                    continue;
                }

                bool loop = true;
                while (loop)
                {
                    Console.WriteLine(@"==========Menu==========
1. Withdraw Money.
2. Deposit Money.
3. Get details.
4. Exit.
========================");
                    int? choice = UserInput.ReadInt("Enter the choice: ", 1, 4);
                    if (choice == null)
                    {
                        Console.WriteLine("returning to main menu");
                        return;
                    }

                    Operation operation = (Operation)choice;
                    switch (operation)
                    {
                        case Operation.WithDraw:
                            {
                                this.Withdraw(account);
                                break;
                            }

                        case Operation.Deposit:
                            {
                                this.Deposit(account);
                                break;
                            }

                        case Operation.FetchDetails:
                            {
                                this.FetchDetails(account);
                                break;
                            }

                        case Operation.Exit:
                            {
                                loop = false;
                                break;
                            }

                        default:
                            {
                                Output.Error("enter valid choice");
                                break;
                            }
                    }
                }
            }
        }

        /// <summary>
        /// creates manager
        /// </summary>
        /// <returns> returns the bank Account</returns>
        public BankAccount? CreateSavingAccount()
        {
            decimal? capital = UserInput.ReadCapital("Enter the capital amount in Rupees: ");
            if (capital == null)
            {
                return null;
            }

            Output.Success("Created Savings account successfully");
            return this._bankServices.CreateSavingAccount((decimal)capital);
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
            return this._bankServices.CreateCheckingAccount((decimal)amount);
        }

        /// <summary>
        /// to withdraw amount
        /// </summary>
        /// <param name="account"> the account in which withdraw takes place</param>
        public void Withdraw(BankAccount account)
        {
            decimal? amount = UserInput.ReadAmount("Enter the amount to be Withdrawn in Rupees: ");
            if (amount == null)
            {
                return;
            }

            switch (this._bankServices.WithDraw(account, (decimal)amount))
            {
                case Message.Successful:
                    {
                        Output.Success("withdraw successful");
                        this.FetchDetails(account);
                        break;
                    }

                case Message.InsufficientBalance:
                    {
                        Output.Error("Amount entered is more than balance ");
                        Console.WriteLine("Back to Menu");
                        break;
                    }

                case Message.MinimumBalance:
                    {
                        Output.Error("invalid - violates minimum balance requirement.");
                        Console.WriteLine("Back to Menu");
                        break;
                    }
            }
        }

        /// <summary>
        /// to deposit amount
        /// </summary>
        /// <param name="account"> the account in which deposit takes place</param>
        public void Deposit(BankAccount account)
        {
            decimal? amount = UserInput.ReadAmount("Enter the amount to be deposited in Rupees: ");
            if (amount == null)
            {
                return;
            }

            this._bankServices.Deposit(account, (decimal)amount);
            Output.Success("Deposit Successful");
        }

        /// <summary>
        /// this fetches details of the account.
        /// </summary>
        /// <param name="account"> account to fetch balance</param>
        public void FetchDetails(BankAccount? account)
        {
            if (account == null)
            {
                Output.Error("No account to fetch details. create one first.");
                return;
            }
            else
            {
                Console.WriteLine(this._bankServices.FetchDetails(account));
            }
        }
    }
}
