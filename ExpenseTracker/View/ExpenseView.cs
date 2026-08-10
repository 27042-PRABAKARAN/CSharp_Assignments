using ExpenseTracker.Model;
using ExpenseTracker.Persistence;
using ExpenseTracker.Service;

namespace ExpenseTracker.View
{
    /// <summary>
    /// Expense view
    /// </summary>
    internal class ExpenseView
    {
        private readonly ExpenseService _expenseServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseView"/> class.
        /// </summary>
        /// <param name="repository"> instance of repository </param>
        public ExpenseView(IRepository repository)
        {
            this._expenseServices = new ExpenseService(repository);
        }

        /// <summary>
        /// operations in Expense
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

                switch ((ExpenseOptions)choice)
                {
                    case ExpenseOptions.Add:
                        {
                            this.AddExpense();
                            UserInput.WaitAndClear();
                            break;
                        }

                    case ExpenseOptions.Delete:
                        {
                            this.DeleteExpense();
                            UserInput.WaitAndClear();
                            break;
                        }

                    case ExpenseOptions.Update:
                        {
                            this.UpdateExpense();
                            UserInput.WaitAndClear();
                            break;
                        }

                    case ExpenseOptions.View:
                        {
                            this.ViewAllExpense();
                            UserInput.WaitAndClear();
                            break;
                        }

                    case ExpenseOptions.Exit:
                        {
                            state = false;
                            return;
                        }
                }
            }
        }

        /// <summary>
        /// Adding an Expense
        /// </summary>
        public void AddExpense()
        {
            Console.Clear();
            Console.WriteLine("Adding a Expense: ");

            decimal? amount = UserInput.ReadPrice("Enter the amount: ");
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

            this._expenseServices.CreateExpense((decimal)amount, (DateOnly)date, (ExpenseType)choice);
            Output.Success("Created Expense Successfully");
        }

        /// <summary>
        /// to view all expense
        /// </summary>
        public void ViewAllExpense()
        {
            Console.Clear();
            bool isEmptyExpenses = this._expenseServices.IsEmptyExpense();

            if (isEmptyExpenses)
            {
                Output.Error("There are no records to display.");
                return;
            }

            IEnumerable<TransactionInfo> transactions = this._expenseServices.GetAllExpenses();
            Console.WriteLine("All Expense Records.");
            Output.PrintTable(transactions);
        }

        /// <summary>
        /// to delete an Expense
        /// </summary>
        public void DeleteExpense()
        {
            if (this._expenseServices.IsEmptyExpense())
            {
                Output.Error("There are no records to display.");
                return;
            }

            IEnumerable<TransactionInfo> transactions = this._expenseServices.GetAllExpenses();
            this.ViewAllExpense();
            int? index = UserInput.ReadInt("Enter S.no: ", 1, transactions.Count());
            if (index == null)
            {
                return;
            }

            index = index - 1;
            if (this._expenseServices.DeleteExpense(transactions.ElementAt((int)index).Id))
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
            if (this._expenseServices.IsEmptyExpense())
            {
                Output.Error("There are no records to display.");
                return;
            }

            IEnumerable<TransactionInfo> transactions = this._expenseServices.GetAllExpenses();
            this.ViewAllExpense();
            int? index = UserInput.ReadInt("Enter S.no: ", 1, transactions.Count());
            if (index == null)
            {
                return;
            }

            index = index - 1;
            Console.WriteLine(@"1. Update Date
2. Update Amount
3. Update Category");
            int? choice = UserInput.ReadInt("Enter choice : ", 1, 3);
            if (choice == null)
            {
                return;
            }

            switch ((Update)choice)
            {
                case Update.Date:
                    {
                        DateOnly? date = UserInput.ReadDate();
                        if (date == null)
                        {
                            return;
                        }

                        if (this._expenseServices.UpdateExpenseDate(transactions.ElementAt((int)index).Id, (DateOnly)date))
                        {
                            Output.Success("Updated Date successfully");
                        }
                        else
                        {
                            Output.Error("Updated Date Failed");
                        }

                        break;
                    }

                case Update.Amount:
                    {
                        decimal? amount = UserInput.ReadPrice("Enter new Amount: ");
                        if (amount == null)
                        {
                            return;
                        }

                        if (this._expenseServices.UpdateExpenseAmount(transactions.ElementAt((int)index).Id, (decimal)amount))
                        {
                            Output.Success("Updated Amount successfully");
                        }
                        else
                        {
                            Output.Error("Updated Amount Failed");
                        }

                        break;
                    }

                case Update.Category:
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

                        if (this._expenseServices.UpdateExpenseCategory(transactions.ElementAt((int)index).Id, ((ExpenseType)category).ToString()))
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
