using ExpenseTracker.Model;
using ExpenseTracker.Model.Enums;
using ExpenseTracker.Service;

namespace ExpenseTracker.View
{
    /// <summary>
    /// Provides operations for managing income and expense transactions.
    /// </summary>
    internal class TransactionView
    {
        private readonly TransactionService _transactionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionView"/> class.
        /// </summary>
        /// <param name="transactionService">
        /// Instance of transaction service.
        /// </param>
        public TransactionView(TransactionService transactionService)
        {
            this._transactionService = transactionService;
        }

        /// <summary>
        /// Displays and manages operations for the specified transaction type.
        /// </summary>
        /// <param name="type">
        /// Type of transaction to manage.
        /// </param>
        public void TransactionManager(TransactionType type)
        {
            bool state = true;

            while (state)
            {
                Console.WriteLine($@"
===========MENU==========
1. Add an {type}
2. Delete an {type}
3. Update an {type}
4. View All {type}
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
                        this.CreateTransaction(type);
                        UserInput.WaitAndClear();
                        break;

                    case TransactionOperations.Delete:
                        this.DeleteTransaction(type);
                        UserInput.WaitAndClear();
                        break;

                    case TransactionOperations.Update:
                        this.UpdateTransaction(type);
                        UserInput.WaitAndClear();
                        break;

                    case TransactionOperations.View:
                        this.ViewAllTransaction(type);
                        UserInput.WaitAndClear();
                        break;

                    case TransactionOperations.Exit:
                        state = false;
                        break;
                }
            }
        }

        /// <summary>
        /// Creates a new transaction.
        /// </summary>
        /// <param name="type">
        /// Type of transaction to create.
        /// </param>
        private void CreateTransaction(TransactionType type)
        {
            Console.Clear();
            Console.WriteLine($"Adding an {type}");

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

            string? category = this.ReadCategory(type);
            if (category == null)
            {
                return;
            }

            this._transactionService.CreateTransaction(amount.Value, date.Value, category, type);
            Output.Success($"Created {type} Successfully");
        }

        /// <summary>
        /// Displays all transactions of the specified type.
        /// </summary>
        /// <param name="type">
        /// Type of transaction to display.
        /// </param>
        private void ViewAllTransaction(TransactionType type)
        {
            Console.Clear();
            IEnumerable<TransactionInfo> transactions = this.GetTransactions(type);
            if (!transactions.Any())
            {
                Output.Error("There are no records to display.");
                return;
            }

            Console.WriteLine($"All {type} Records:");
            Output.PrintTransactionTable(transactions);
        }

        /// <summary>
        /// Deletes a transaction of the specified type.
        /// </summary>
        /// <param name="type">
        /// Type of transaction to delete.
        /// </param>
        private void DeleteTransaction(TransactionType type)
        {
            IEnumerable<TransactionInfo> transactions = this.GetTransactions(type);
            if (!transactions.Any())
            {
                Output.Error("There are no records to display.");
                return;
            }

            this.ViewAllTransaction(type);
            List<TransactionInfo> transactionList = this.GetTransactions(type).ToList();
            int? serialNumber = UserInput.ReadInt("Enter S.no: ", 1, transactionList.Count);
            if (serialNumber == null)
            {
                return;
            }

            TransactionInfo transaction = transactionList[serialNumber.Value - 1];
            if (this._transactionService.DeleteTransaction(transaction.Id))
            {
                Output.Success("Deleted Successfully");
            }
            else
            {
                Output.Error("Record not deleted");
            }
        }

        /// <summary>
        /// Updates a transaction of the specified type.
        /// </summary>
        /// <param name="type">
        /// Type of transaction to update.
        /// </param>
        private void UpdateTransaction(TransactionType type)
        {
            IEnumerable<TransactionInfo> transactions = this.GetTransactions(type);
            if (!transactions.Any())
            {
                Output.Error("There are no records to display.");
                return;
            }

            this.ViewAllTransaction(type);
            List<TransactionInfo> transactionList = this.GetTransactions(type).ToList();

            int? serialNumber = UserInput.ReadInt("Enter S.no: ", 1, transactionList.Count);
            if (serialNumber == null)
            {
                return;
            }

            TransactionInfo transaction = transactionList[serialNumber.Value - 1];
            Console.WriteLine(@"1. Update Date
2. Update Amount
3. Update Category");

            int? choice = UserInput.ReadInt("Enter choice: ", 1, 3);
            if (choice == null)
            {
                return;
            }

            switch ((UpdateOptions)choice)
            {
                case UpdateOptions.Date:
                    this.UpdateTransactionDate(transaction.Id);
                    break;

                case UpdateOptions.Amount:
                    this.UpdateTransactionAmount(transaction.Id);
                    break;

                case UpdateOptions.Category:
                    this.UpdateTransactionCategory(transaction.Id, type);
                    break;
            }
        }

        /// <summary>
        /// Updates the date of a transaction.
        /// </summary>
        /// <param name="transactionId">
        /// Id of the transaction.
        /// </param>
        private void UpdateTransactionDate(string transactionId)
        {
            DateOnly? date = UserInput.ReadDate();
            if (date == null)
            {
                return;
            }

            if (this._transactionService.UpdateTransactionDate(transactionId, date.Value))
            {
                Output.Success("Updated Date Successfully");
            }
            else
            {
                Output.Error("Updated Date Failed");
            }
        }

        /// <summary>
        /// Updates the amount of a transaction.
        /// </summary>
        /// <param name="transactionId">
        /// Id of the transaction.
        /// </param>
        private void UpdateTransactionAmount(string transactionId)
        {
            decimal? amount = UserInput.ReadAmount("Enter new Amount: ");
            if (amount == null)
            {
                return;
            }

            if (this._transactionService.UpdateTransactionAmount(transactionId, amount.Value))
            {
                Output.Success("Updated Amount Successfully");
            }
            else
            {
                Output.Error("Updated Amount Failed");
            }
        }

        /// <summary>
        /// Updates the category of a transaction.
        /// </summary>
        /// <param name="transactionId">
        /// Id of the transaction.
        /// </param>
        /// <param name="type">
        /// Type of transaction.
        /// </param>
        private void UpdateTransactionCategory(string transactionId, TransactionType type)
        {
            string? category = this.ReadCategory(type);
            if (category == null)
            {
                return;
            }

            if (this._transactionService.UpdateTransactionCategory(transactionId, category))
            {
                Output.Success("Updated Category Successfully");
            }
            else
            {
                Output.Error("Updated Category Failed");
            }
        }

        /// <summary>
        /// Reads the category for the specified transaction type.
        /// </summary>
        /// <param name="type">
        /// Type of transaction.
        /// </param>
        /// <returns>
        /// Selected category, or null if the operation is cancelled.
        /// </returns>
        private string? ReadCategory(TransactionType type)
        {
            Console.WriteLine($"Enter Category of {type}: ");
            if (type == TransactionType.Income)
            {
                Console.WriteLine(@"1. Salary
2. Investment Returns
3. Bonus
4. Others");

                int? choice = UserInput.ReadInt("Enter choice: ", 1, 4);
                if (choice == null)
                {
                    return null;
                }

                return ((IncomeType)choice.Value).ToString();
            }

            Console.WriteLine(@"1. Food
2. Travel
3. Emergency
4. Health");

            int? expenseChoice = UserInput.ReadInt("Enter choice: ", 1, 4);
            if (expenseChoice == null)
            {
                return null;
            }

            return ((ExpenseType)expenseChoice.Value).ToString();
        }

        /// <summary>
        /// Gets transactions belonging to the specified transaction type.
        /// </summary>
        /// <param name="type">
        /// Type of transaction.
        /// </param>
        /// <returns>
        /// Transactions belonging to the specified type.
        /// </returns>
        private IEnumerable<TransactionInfo> GetTransactions(TransactionType type)
        {
            if (type == TransactionType.Income)
            {
                return this._transactionService.GetAllIncomes();
            }

            return this._transactionService.GetAllExpenses();
        }
    }
}