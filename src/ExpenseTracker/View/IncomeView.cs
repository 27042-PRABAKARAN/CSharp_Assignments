using ExpenseTracker.Model.Enums;
using ExpenseTracker.Persistence;
using ExpenseTracker.Service;

namespace ExpenseTracker.View
{
    /// <summary>
    /// Income view
    /// </summary>
    internal class IncomeView
    {
        private readonly IncomeService _incomeServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="IncomeView"/> class.
        /// </summary>
        /// <param name="repository"> instance of repository </param>
        public IncomeView(IRepository repository)
        {
            this._incomeServices = new IncomeService(repository);
        }

        /// <summary>
        /// operations in Income
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
                            return;
                        }
                }
            }
        }

        /// <summary>
        /// Adding a income
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

            this._incomeServices.CreateIncome((decimal)amount, (DateOnly)date, (IncomeType)choice);
            Output.Success("Created Income Successfully");
        }

        /// <summary>
        /// to view all income
        /// </summary>
        public void ViewAllIncome()
        {
            Console.Clear();
            bool isEmptyIncomes = this._incomeServices.IsEmptyIncome();

            if (isEmptyIncomes)
            {
                Output.Error("There are no records to display.");
                return;
            }

            IEnumerable<TransactionInfo> transactions = this._incomeServices.GetAllIncomes();
            Console.WriteLine("All income Records:");
            Output.PrintTable(transactions);
        }

        /// <summary>
        /// to delete an income
        /// </summary>
        public void DeleteIncome()
        {
            if (this._incomeServices.IsEmptyIncome())
            {
                Output.Error("There are no records to display.");
                return;
            }

            IEnumerable<TransactionInfo> transactions = this._incomeServices.GetAllIncomes();
            this.ViewAllIncome();
            int? serialNumber = UserInput.ReadInt("Enter S.no: ", 1, transactions.Count());
            if (serialNumber == null)
            {
                return;
            }

            int? index = serialNumber - 1;
            if (this._incomeServices.DeleteIncome(transactions.ElementAt((int)index).Id))
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
            if (this._incomeServices.IsEmptyIncome())
            {
                Output.Error("There are no records to display.");
                return;
            }

            this.ViewAllIncome();
            IEnumerable<TransactionInfo> transactions = this._incomeServices.GetAllIncomes();
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

            switch ((UpdateOptions)choice)
            {
                case UpdateOptions.Date:
                    {
                        DateOnly? date = UserInput.ReadDate();
                        if (date == null)
                        {
                            return;
                        }

                        if (this._incomeServices.UpdateIncomeDate(transactions.ElementAt((int)index).Id, (DateOnly)date))
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

                        if (this._incomeServices.UpdateIncomeAmount(transactions.ElementAt((int)index).Id, (decimal)amount))
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

                        if (this._incomeServices.UpdateIncomeCategory(transactions.ElementAt((int)index).Id, ((IncomeType)category).ToString()))
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
