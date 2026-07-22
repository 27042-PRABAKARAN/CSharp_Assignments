namespace Assignment2.Helper
{
    /// <summary>
    /// Input class for taking inputs
    /// </summary>
    public static class UserInput
    {
        /// <summary>
        /// this reads the input
        /// </summary>
        /// <param name="prompt"> the prompt for the input </param>
        /// <returns> returns string </returns>
        public static string? ReadInput(string? prompt)
        {
            Console.Write(prompt);
            string? userInput = Validation.GetValidInput(prompt, Validation.IsValidInput, "Enter a value");
            return userInput;
        }
    }
}
