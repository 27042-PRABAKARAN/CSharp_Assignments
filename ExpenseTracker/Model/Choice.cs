using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Model
{
    /// <summary>
    /// enum of choice
    /// </summary>
    internal enum Choice
    {
        /// <summary>
        /// to add
        /// </summary>
        Add = 1,

        /// <summary>
        /// to delete
        /// </summary>
        Delete,

        /// <summary>
        /// to update
        /// </summary>
        Update,

        /// <summary>
        /// to view
        /// </summary>
        View,

        /// <summary>
        /// to exit
        /// </summary>
        Exit,
    }
}
