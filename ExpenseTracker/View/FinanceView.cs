using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Model;
using ExpenseTracker.Service;

namespace ExpenseTracker.View
{
    /// <summary>
    /// the view layer of finance tracker
    /// </summary>
    internal class FinanceView
    {
        private readonly TransactionServices _transactionServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="FinanceView"/> class.
        /// </summary>
        /// <param name="service"> instance of services</param>
        public FinanceView(TransactionServices service)
        {
            this._transactionServices = service;
        }

        /// <summary>
        /// operation that can be made in this applications.
        /// </summary>
        public void FinanceOperations()
        {
            Console.WriteLine("Hey User,");
            Console.WriteLine("Welcome to Finance tracker");
            bool state = true;
            while (state)
            {
                Console.WriteLine(@"===========MENU==========
1. Income Options
2. Expense Options
3. Generate Summary
4. Exit
=========================");
                int? choice = UserInput.ReadChoice("Enter your choice: ");
                if (choice == null)
                {
                    return;
                }

                switch ((TransactionType)choice)
                {
                    case TransactionType.Income:
                        {
                            Console.Clear();
                            this.IncomeOperations();
                            UserInput.WaitAndClear();
                            break;
                        }

                    case TransactionType.Expense:
                        {
                            Console.Clear();
                            this.ExpenseOperations();
                            UserInput.WaitAndClear();
                            break;
                        }

                    case TransactionType.Summary:
                        {
                            Console.Clear();
                            this.GenerateSummary();
                            UserInput.WaitAndClear();
                            break;
                        }

                    case TransactionType.Exit:
                        {
                            state = false;
                            break;
                        }

                    default:
                        {
                            Output.Error("Enter Valid Input");
                            break;
                        }
                }
            }
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

                switch ((IncomeOptions)choice)
                {
                    case IncomeOptions.Add:
                        {
                            this.AddIncome();
                            UserInput.WaitAndClear();
                            break;
                        }

                    case IncomeOptions.Delete:
                        {
                            this.DeleteIncome();
                            UserInput.WaitAndClear();
                            break;
                        }

                    case IncomeOptions.Update:
                        {
                            this.UpdateIncome();
                            UserInput.WaitAndClear();
                            break;
                        }

                    case IncomeOptions.View:
                        {
                            this.ViewAllIncome();
                            UserInput.WaitAndClear();
                            break;
                        }

                    case IncomeOptions.Exit:
                        {
                            state = false;
                            return;
                        }
                }
            }
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
                            this.AddIncome();
                            UserInput.WaitAndClear();
                            break;
                        }

                    case ExpenseOptions.Delete:
                        {
                            this.DeleteIncome();
                            UserInput.WaitAndClear();
                            break;
                        }

                    case ExpenseOptions.Update:
                        {
                            this.UpdateIncome();
                            UserInput.WaitAndClear();
                            break;
                        }

                    case ExpenseOptions.View:
                        {
                            this.ViewAllIncome();
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
        /// Adding a income
        /// </summary>
        public void AddIncome()
        {
            Console.Clear();
            Console.WriteLine("Adding an Income");

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

            this._transactionServices.CreateIncome((decimal)amount, (DateOnly)date, (Source)choice);
            Output.Success("Created Income Successfully");
        }

        /// <summary>
        /// Adding an Expense
        /// </summary>
        public void AddExpense()
        {
            Console.Clear();
            Console.WriteLine("Adding an Income");

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

            this._transactionServices.CreateExpense((decimal)amount, (DateOnly)date, (ExpenseType)choice);
            Output.Success("Created Expense Successfully");
            }

        /// <summary>
        /// to view all income
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
            bool isEmptyExpenses = this._transactionServices.IsEmptyExpense();
        }

        /// <summary>
        /// to view all expense
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
            Console.WriteLine("All income Records.");
            Output.PrintTable(transactions);
        }

        /// <summary>
        /// to delete an income
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
            int? index = UserInput.ReadInt("Enter S.no: ", 1, transactions.Count());
            if (index == null)
            {
                return;
            }

            index = index - 1;
            if (this._transactionServices.DeleteIncome(transactions.ElementAt((int)index).Id))
            {
                Output.Success("Deleted Successfully");
            }
            else
            {
                Output.Error("Record not deleted");
            }
        }

        /// <summary>
        /// to delete an Expense
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
            int? index = UserInput.ReadInt("Enter S.no: ", 1, transactions.Count());
            if (index == null)
            {
                return;
            }

            index = index - 1;
            if (this._transactionServices.DeleteExpense(transactions.ElementAt((int)index).Id))
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

                        if (this._transactionServices.UpdateIncomeDate(transactions.ElementAt((int)index).Id, (DateOnly)date))
                        {
                            Output.Success("Updated Date successfully");
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

                        if (this._transactionServices.UpdateIncomeAmount(transactions.ElementAt((int)index).Id, (decimal)amount))
                        {
                            Output.Success("Updated Amount successfully");
                        }

                        break;
                    }

                case Update.Category:
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

                        if (this._transactionServices.UpdateIncomeCategory(transactions.ElementAt((int)index).Id, ((Source)category).ToString()))
                        {
                            Output.Success("Updated Category successfully");
                        }

                        break;
                    }
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

                        if (this._transactionServices.UpdateExpenseDate(transactions.ElementAt((int)index).Id, (DateOnly)date))
                        {
                            Output.Success("Updated Date successfully");
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

                        if (this._transactionServices.UpdateExpenseAmount(transactions.ElementAt((int)index).Id, (decimal)amount))
                        {
                            Output.Success("Updated Amount successfully");
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

                        if (this._transactionServices.UpdateExpenseCategory(transactions.ElementAt((int)index).Id, ((Source)category).ToString()))
                        {
                            Output.Success("Updated Category successfully");
                        }

                        break;
                    }
            }
        }

        /// <summary>
        /// to generate summary
        /// </summary>
        public void GenerateSummary()
        {
            if (this._transactionServices.IsEmptyIncome() && this._transactionServices.IsEmptyExpense())
            {
                Output.Error("no records for generating summary");
                return;
            }

            decimal income = this._transactionServices.GetTotalIncome();
            decimal expense = this._transactionServices.GetTotalExpense();
            Console.WriteLine($@"=========Summary========
Total Income: {income}
Total Expense: {expense}
");
            if (income >= expense)
            {
                Console.WriteLine($"You have saved {income - expense} Rupees");
            }
            else
            {
                Console.WriteLine($"You have exceeded {expense - income} Rupees");
            }
        }
    }
}
