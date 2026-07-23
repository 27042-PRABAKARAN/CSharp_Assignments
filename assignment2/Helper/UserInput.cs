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

        /// <summary>
        /// this reads the input
        /// </summary>
        /// <param name="prompt"> the prompt for the input </param>
        /// <returns> returns string </returns>
        public static decimal? ReadAmount(string? prompt)
        {
            for (int tried = 1; tried <= 3; tried++)
            {
                if (!decimal.TryParse(UserInput.ReadInput(prompt), out decimal amount) || amount <= 0)
                {
                    Output.Error("Invalid Amount. Please enter a positive number.");
                }
                else
                {
                    return amount;
                }

                Output.Error($"{3 - tried} attempts remaining\n");
            }

            return null;
        }
    }
}
