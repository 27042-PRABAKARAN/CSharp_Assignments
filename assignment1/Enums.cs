using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    /// <summary>
    /// Enum for searching choices
    /// </summary>
    public enum Choice
    {
        /// <summary>
        /// Name
        /// </summary>
        Name = 1,

        /// <summary>
        /// Email
        /// </summary>
        Email = 2,

        /// <summary>
        /// Contact
        /// </summary>
        Contact = 3,

        /// <summary>
        /// Description
        /// </summary>
        Description = 4,
    }

    /// <summary>
    /// Enum Operations created
    /// </summary>
    /// <value>
    /// Converts user choice to meaningful operations
    /// </value>
    internal enum Operation
    {
        /// <summary>
        /// Add operation
        /// </summary>
        Add = 1,

        /// <summary>
        /// View Operation
        /// </summary>
        View,

        /// <summary>
        /// Search Operation
        /// </summary>
        Search,

        /// <summary>
        /// Edit operation
        /// </summary>
        Edit,

        /// <summary>
        /// Delete operation
        /// </summary>
        Delete,

        /// <summary>
        /// Exiting
        /// </summary>
        Exit,
    }
}
