using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace ExpenseTracker.Model
{
    /// <summary>
    /// Transaction interface
    /// </summary>
    internal interface ITransaction
    {
        /// <summary>
        /// Gets or sets transaction amount
        /// </summary>
        /// <value>
        /// Transaction amount
        /// </value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets transaction Id
        /// </summary>
        /// <value>
        /// Transaction ID
        /// </value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the date of transaction
        /// </summary>
        /// <value>
        /// date of transaction
        /// </value>
        public DateOnly Date { get; set; }

    }
}
