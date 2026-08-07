using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Model
{
    /// <summary>
    /// Type of expenses
    /// </summary>
    internal enum ExpenseType
    {
        /// <summary>
        /// expenses for food
        /// </summary>
        Food,

        /// <summary>
        /// expenses for travel
        /// </summary>
        Travel,

        /// <summary>
        /// expenses for Emergency
        /// </summary>
        Emergency,

        /// <summary>
        /// expenses for Health
        /// </summary>
        Health,
    }
}
