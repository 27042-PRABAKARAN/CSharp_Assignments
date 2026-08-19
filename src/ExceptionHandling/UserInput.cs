namespace ExceptionHandling.Helper
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
        public static decimal? ReadCapital(string? prompt)
        {
            for (int tried = 1; tried <= 3; tried++)
            {
                Console.Write(prompt);
                if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount < 5000)
                {
                    Output.Error("Invalid Amount. Minimum balance is 5000 Rupees.");
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
        /// this reads Double value.
        /// </summary>
        /// <param name="prompt"> to prompt the message </param>
        /// <returns>long value</returns>
        public static double? ReadDouble(string? prompt)
        {
            for (int tried = 1; tried <= 3; tried++)
            {
                Console.Write(prompt);
                if (!double.TryParse(Console.ReadLine(), out double number))
                {
                    Output.Error($"Invalid Number.");
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
