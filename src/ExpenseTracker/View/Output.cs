using ConsoleTables;
using ExpenseTracker.Model;
using ExpenseTracker.Model.Enums;

namespace ExpenseTracker.View
{
    /// <summary>
    /// Display class is used for displaying output
    /// </summary>
    public static class Output
    {
        /// <summary>
        /// To print the message in red
        /// </summary>
        /// <param name="message">the message that has to be printed in red</param>
        public static void Error(string? message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// To print the message in Green
        /// </summary>
        /// <param name="message">the message that has to be printed in Green</param>
        public static void Success(string? message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// To display as tables.
        /// </summary>
        /// <param name="transactions"> the list to be printed as tables </param>
        internal static void PrintTable(IEnumerable<TransactionInfo> transactions)
        {
            Console.WriteLine();
            var table = new ConsoleTable("S.no", "TransactionId", "Transaction Date", "Transaction Amount", "Category");
            int i = 0;
            foreach (TransactionInfo transaction in transactions)
            {
                table.AddRow(++i, transaction.Id, transaction.Date, transaction.Amount, transaction.Category);
            }

            table.Write(Format.Alternative);
        }
    }
}
