namespace ExceptionHandling
{
    /// <summary>
    /// Custom Exception created
    /// </summary>
    internal class InvalidUserInputException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidUserInputException"/> class.
        /// </summary>
        /// <param name="message"> Exception message </param>
        public InvalidUserInputException(string? message)
            : base(message)
        {
        }
    }
}
