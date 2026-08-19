using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    /// <summary>
    /// Custom Exception created
    /// </summary>
    internal class UserInputException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserInputException"/> class.
        /// </summary>
        /// <param name="message"> Exception message </param>
        public UserInputException(string? message)
            : base(message)
        {
        }
    }
}
