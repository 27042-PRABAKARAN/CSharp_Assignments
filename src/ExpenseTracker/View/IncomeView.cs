using ExpenseTracker.Model;
using ExpenseTracker.Model.Enums;
using ExpenseTracker.Service;

namespace ExpenseTracker.View
{
    /// <summary>
    /// Income view
    /// </summary>
    internal class IncomeView
    {
        private readonly TransactionService _transactionServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="IncomeView"/> class.
        /// </summary>
        /// <param name="incomeService"> instance of income service </param>
        public IncomeView(TransactionService incomeService)
        {
            this._transactionServices = incomeService;
        }

        /// <summary>
        /// Operations in Income
        /// </summary>
        public void IncomeOperations()
        {
            bool state = true;
            while (state)
            {
                Console.WriteLine(@"===========MENU==========
1. Add an Income
2. Delete an Income
3. Update an Income
4. View All Income
5. Exit
=========================");
                int? choice = UserInput.ReadInt("Enter your choice: ", 1, 5);
                if (choice == null)
                {
                    return;
                }

                switch ((TransactionOperations)choice)
                {
                    case TransactionOperations.Add:
                        {
                            this.CreateIncome();
                            UserInput.WaitAndClear();
                            break;
                        }

                    case TransactionOperations.Delete:
                        {
                            this.DeleteIncome();
                            UserInput.WaitAndClear();
                            break;
                        }

                    case TransactionOperations.Update:
                        {
                            this.UpdateIncome();
                            UserInput.WaitAndClear();
                            break;
                        }

                    case TransactionOperations.View:
                        {
                            this.ViewAllIncome();
                            UserInput.WaitAndClear();
                            break;
                        }

                    case TransactionOperations.Exit:
                        {
                            state = false;
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// Creating a income
        /// </summary>
        public void CreateIncome()
        {
            Console.Clear();
            Console.WriteLine("Adding an Income");

            decimal? amount = UserInput.ReadAmount("Enter the amount: ");
            if (amount == null)
            {
                return;
            }

            DateOnly? date = UserInput.ReadDate();
            if (date == null)
            {
                return;
            }

            Console.WriteLine("Enter the Type of income: ");
            Console.WriteLine(@"1. Salary
2. Investment Returns.
3. Bonus.
4. Others.");
            int? choice = UserInput.ReadInt("Enter choice: ", 1, 4);
            if (choice == null)
            {
                return;
            }

            this._transactionServices.CreateTransaction((decimal)amount, (DateOnly)date, ((IncomeType)choice).ToString(), TransactionType.Income);
            Output.Success("Created Income Successfully");
        }

        /// <summary>
        /// To view all income
        /// </summary>
        public void ViewAllIncome()
        {
            Console.Clear();
            bool isEmptyIncomes = this._transactionServices.IsEmptyIncome();

            if (isEmptyIncomes)
            {
                Output.Error("There are no records to display.");
                return;
            }

            IEnumerable<TransactionInfo> transactions = this._transactionServices.GetAllIncomes();
            Console.WriteLine("All income Records:");
            Output.PrintTable(transactions);
        }

        /// <summary>
        /// To delete an income
        /// </summary>
        public void DeleteIncome()
        {
            if (this._transactionServices.IsEmptyIncome())
            {
                Output.Error("There are no records to display.");
                return;
            }

            IEnumerable<TransactionInfo> transactions = this._transactionServices.GetAllIncomes();
            this.ViewAllIncome();
            int? serialNumber = UserInput.ReadInt("Enter S.no: ", 1, transactions.Count());
            if (serialNumber == null)
            {
                return;
            }

            int? index = serialNumber - 1;
            if (this._transactionServices.DeleteTransaction(transactions.ElementAt((int)index).Id))
            {
                Output.Success("Deleted Successfully");
            }
            else
            {
                Output.Error("Record not deleted");
            }
        }

        /// <summary>
        /// To update income
        /// </summary>
        public void UpdateIncome()
        {
            if (this._transactionServices.IsEmptyIncome())
            {
                Output.Error("There are no records to display.");
                return;
            }

            this.ViewAllIncome();
            IEnumerable<TransactionInfo> transactions = this._transactionServices.GetAllIncomes();
            int? index = UserInput.ReadInt("Enter S.no: ", 1, transactions.Count());
            if (index == null)
            {
                return;
            }

            index--;
            Console.WriteLine(@"1. Update Date
2. Update Amount
3. Update Category");
            int? choice = UserInput.ReadInt("Enter choice : ", 1, 3);
            if (choice == null)
            {
                return;
            }

            switch ((UpdateOptions)choice)
            {
                case UpdateOptions.Date:
                    {
                        DateOnly? date = UserInput.ReadDate();
                        if (date == null)
                        {
                            return;
                        }

                        if (this._transactionServices.UpdateTransactionDate(transactions.ElementAt((int)index).Id, (DateOnly)date))
                        {
                            Output.Success("Updated Date successfully");
                        }
                        else
                        {
                            Output.Error("Update failed");
                        }

                        break;
                    }

                case UpdateOptions.Amount:
                    {
                        decimal? amount = UserInput.ReadAmount("Enter new Amount: ");
                        if (amount == null)
                        {
                            return;
                        }

                        if (this._transactionServices.UpdateTransactionAmount(transactions.ElementAt((int)index).Id, (decimal)amount))
                        {
                            Output.Success("Updated Amount successfully");
                        }
                        else
                        {
                            Output.Error("Update failed");
                        }

                        break;
                    }

                case UpdateOptions.Category:
                    {
                        Console.WriteLine("Enter the Type of income: ");
                        Console.WriteLine(@"1. Salary
2. Investment Returns.
3. Bonus.
4. Others.");
                        int? category = UserInput.ReadInt("Enter choice: ", 1, 4);
                        if (category == null)
                        {
                            return;
                        }

                        if (this._transactionServices.UpdateTransactionCategory(transactions.ElementAt((int)index).Id, ((IncomeType)category).ToString()))
                        {
                            Output.Success("Updated Category successfully");
                        }
                        else
                        {
                            Output.Error("Update failed");
                        }

                        break;
                    }
            }
        }
    }
}
