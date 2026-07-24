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
            string? userInput = Validation.GetValidInput(prompt, Validation.IsValidInput, "Nothing Entered !!");
            return userInput;
        }

        /// <summary>
        /// to get the colour of string.
        /// </summary>
        /// <param name="prompt"> promt the user </param>
        /// <returns> returns colour </returns>
        public static string? GetColour(string? prompt)
        {
            for (int tried = 1; tried <= 3; tried++)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();
                if (!Validation.IsValidInput(input) || input == null)
                {
                    Output.Error("Enter valid colour(colour should be only contain alphabets.");
                    Output.Error($"{3 - tried} attempts remaining\n");
                    continue;
                }

                if (!input.All(char.IsLetter))
                {
                    Output.Error("Enter valid colour(colour should be only contain alphabets.");
                    Output.Error($"{3 - tried} attempts remaining\n");
                }
                else
                {
                    return input;
                }
            }

            return null;
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
                Console.Write(prompt);
                if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount <= 0)
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

        /// <summary>
        /// this reads number.
        /// </summary>
        /// <param name="prompt"> to prompt the message </param>
        /// <param name="minRange"> the minimum range  </param>
        /// <param name="maxRange"> the maximum range </param>
        /// <returns> returns read number </returns>
        public static int? ReadInt(string? prompt, int minRange, int maxRange)
        {
            for (int tried = 1; tried <= 3; tried++)
            {
                Console.Write(prompt);
                if (!int.TryParse(Console.ReadLine(), out int number) || number > maxRange || number < minRange)
                {
                    Output.Error($"Invalid Number. Please enter a number between {minRange} to {maxRange}.");
                }
                else
                {
                    return number;
                }

                Output.Error($"{3 - tried} attempts remaining\n");
            }

            return null;
        }

        /// <summary>
        /// this reads salary.
        /// </summary>
        /// <param name="prompt"> to prompt the message </param>
        /// <returns> returns read number </returns>
        public static double? ReadSalary(string? prompt)
        {
            for (int tried = 1; tried <= 3; tried++)
            {
                Console.Write(prompt);
                if (!double.TryParse(Console.ReadLine(), out double salary) || salary <= 0)
                {
                    Output.Error($"Invalid Salary. Please enter a Salary more than 0.");
                }
                else
                {
                    return salary;
                }

                Output.Error($"{3 - tried} attempts remaining\n");
            }

            return null;
        }

        /// <summary>
        /// this reads Meters.
        /// </summary>
        /// <param name="prompt"> to prompt the message </param>
        /// <returns> returns read number </returns>
        public static double? ReadMetres(string? prompt)
        {
            for (int tried = 1; tried <= 3; tried++)
            {
                Console.Write(prompt);
                if (!double.TryParse(Console.ReadLine(), out double meters) || meters <= 0)
                {
                    Output.Error($"Invalid Entry. meters should be an number more than 0.");
                }
                else
                {
                    return meters;
                }

                Output.Error($"{3 - tried} attempts remaining\n");
            }

            return null;
        }
    }
}
