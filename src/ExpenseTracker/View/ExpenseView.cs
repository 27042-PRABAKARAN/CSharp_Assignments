using ExpenseTracker.Model;
using ExpenseTracker.Model.Enums;
using ExpenseTracker.Service;

namespace ExpenseTracker.View
{
    /// <summary>
    /// Expense view
    /// </summary>
    internal class ExpenseView
    {
        private readonly TransactionService _transactionServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseView"/> class.
        /// </summary>
        /// <param name="expenseService"> instance of Expense services </param>
        public ExpenseView(TransactionService expenseService)
        {
            this._transactionServices = expenseService;
        }

        /// <summary>
        /// Operations in Expense
        /// </summary>
        public void ExpenseOperations()
        {
            bool state = true;
            while (state)
            {
                Console.WriteLine(@"===========MENU==========
1. Add an Expense
2. Delete an Expense
3. Update an Expense
4. View All Expense
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
                            this.CreateExpense();
                            UserInput.WaitAndClear();
                            break;
                        }

                    case TransactionOperations.Delete:
                        {
                            this.DeleteExpense();
                            UserInput.WaitAndClear();
                            break;
                        }

                    case TransactionOperations.Update:
                        {
                            this.UpdateExpense();
                            UserInput.WaitAndClear();
                            break;
                        }

                    case TransactionOperations.View:
                        {
                            this.ViewAllExpense();
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
        /// Creating an Expense
        /// </summary>
        public void CreateExpense()
        {
            Console.Clear();
            Console.WriteLine("Adding a Expense: ");

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

            Console.WriteLine(@"1. Food
2. Travel.
3. Emergency.
4. Health.");
            int? choice = UserInput.ReadInt("Enter choice: ", 1, 4);
            if (choice == null)
            {
                return;
            }

            this._transactionServices.CreateTransaction((decimal)amount, (DateOnly)date, ((ExpenseType)choice).ToString(), TransactionType.Expense);
            Output.Success("Created Expense Successfully");
        }

        /// <summary>
        /// To view all expense
        /// </summary>
        public void ViewAllExpense()
        {
            Console.Clear();
            bool isEmptyExpenses = this._transactionServices.IsEmptyExpense();

            if (isEmptyExpenses)
            {
                Output.Error("There are no records to display.");
                return;
            }

            IEnumerable<TransactionInfo> transactions = this._transactionServices.GetAllExpenses();
            Console.WriteLine("All Expense Records.");
            Output.PrintTable(transactions);
        }

        /// <summary>
        /// To delete an Expense
        /// </summary>
        public void DeleteExpense()
        {
            if (this._transactionServices.IsEmptyExpense())
            {
                Output.Error("There are no records to display.");
                return;
            }

            IEnumerable<TransactionInfo> transactions = this._transactionServices.GetAllExpenses();
            this.ViewAllExpense();
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
        /// To update Expense
        /// </summary>
        public void UpdateExpense()
        {
            if (this._transactionServices.IsEmptyExpense())
            {
                Output.Error("There are no records to display.");
                return;
            }

            IEnumerable<TransactionInfo> transactions = this._transactionServices.GetAllExpenses();
            this.ViewAllExpense();
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
                            Output.Error("Updated Date Failed");
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
                            Output.Error("Updated Amount Failed");
                        }

                        break;
                    }

                case UpdateOptions.Category:
                    {
                        Console.WriteLine("Enter the Type of Expense: ");
                        Console.WriteLine(@"1. Food
2. Travel.
3. Emergency.
4. Health.");
                        int? category = UserInput.ReadInt("Enter choice: ", 1, 4);
                        if (category == null)
                        {
                            return;
                        }

                        if (this._transactionServices.UpdateTransactionCategory(transactions.ElementAt((int)index).Id, ((ExpenseType)category).ToString()))
                        {
                            Output.Success("Updated Category successfully");
                        }
                        else
                        {
                            Output.Error("Updated Category Failed");
                        }

                        break;
                    }
            }
        }
    }
}
