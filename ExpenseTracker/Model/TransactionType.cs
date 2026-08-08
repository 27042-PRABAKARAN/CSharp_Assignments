using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Model
{
    /// <summary>
    /// Type of transaction
    /// </summary>
    internal enum TransactionType
    {
        /// <summary>
        /// Income Type
        /// </summary>
        Income = 1,

        /// <summary>
        /// Expense Type
        /// </summary>
        Expense,

        /// <summary>
        /// summary of Both Income and Expense
        /// </summary>
        Summary,

        /// <summary>
        /// Exit
        /// </summary>
        Exit,
    }
}
