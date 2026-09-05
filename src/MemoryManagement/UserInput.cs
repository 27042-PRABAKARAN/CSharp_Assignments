using System.Text.RegularExpressions;

namespace MemoryManagement
{
    /// <summary>
    /// User input class to read input from users
    /// </summary>
    public static class UserInput
    {
        private const int _tries = 3;

        /// <summary>
        /// Reads name from user
        /// </summary>
        /// <param name="prompt"> prompt for user to enter</param>
        /// <returns> name </returns>
        public static string? ReadName(string prompt)
        {
            for (int i = 0; i < _tries; i++)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();
                if (input == null)
                {
                    Console.WriteLine("Enter an input");
                    Console.WriteLine("{_tries - i} tries left");
                    continue;
                }

                if (!Regex.IsMatch(input, "^[A-Za-z0-9]+$"))
                {
                    Console.WriteLine("Name should be in letters and numbers only");
                    Console.WriteLine("{_tries - i} tries left");
                    continue;
                }

                return input;
            }

            return null;
        }

        /// <summary>
        /// To read Email
        /// </summary>
        /// <param name="prompt"> Prompt the user</param>
        /// <returns> Email from user </returns>
        public static string? ReadEmail(string prompt)
        {
            for (int i = 0; i < _tries; i++)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();
                if (input == null)
                {
                    Console.WriteLine("Enter an input");
                    Console.WriteLine("{_tries - i} tries left");
                    continue;
                }

                if (!Regex.IsMatch(input, "^[A-Za-z0-9]@+[A-Za-z]+.[A-Za-z]+$"))
                {
                    Console.WriteLine("Email should be like abc@mail.com");
                    Console.WriteLine("{_tries - i} tries left");
                    continue;
                }

                return input;
            }

            return null;
        }

        /// <summary>
        /// To read Password
        /// </summary>
        /// <param name="prompt"> Prompt the user</param>
        /// <returns> Password from user </returns>
        public static string? ReadPassword(string prompt)
        {
            for (int i = 0; i < _tries; i++)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();
                if (input == null)
                {
                    Console.WriteLine("Enter an input");
                    Console.WriteLine("{_tries - i} tries left");
                    continue;
                }

                return input;
            }

            return null;
        }

        /// <summary>
        /// To read Contact
        /// </summary>
        /// <param name="prompt"> Prompt the user</param>
        /// <returns> Contact from user </returns>
        public static string? ReadContact(string prompt)
        {
            for (int i = 0; i < _tries; i++)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();
                if (input == null)
                {
                    Console.WriteLine("Enter an input");
                    Console.WriteLine("{_tries - i} tries left");
                    continue;
                }

                if (!Regex.IsMatch(input, "^[0-9]{10}$"))
                {
                    Console.WriteLine("Contact should be of 10 numbers only");
                    Console.WriteLine("{_tries - i} tries left");
                    continue;
                }

                return input;
            }

            return null;
        }

        /// <summary>
        /// To read number input
        /// </summary>
        /// <param name="prompt"> to prompt user</param>
        /// <param name="min"> minimum number to enter</param>
        /// <param name="max"> Maximum input number </param>
        /// <returns> integer or null</returns>
        public static int? ReadInt(string prompt, int min, int max)
        {
            for (int i = 0; i < _tries; i++)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();
                if (input == null)
                {
                    Console.WriteLine("Enter an input");
                    Console.WriteLine("{_tries - i} tries left");
                    continue;
                }

                if (!int.TryParse(input, out int number) || !(number >= min) || !(number <= max))
                {
                    Console.WriteLine($"Enter a number between {min} and {max}.");
                    Console.WriteLine("{_tries - i} tries left");
                    continue;
                }

                return number;
            }

            return null;
        }

        /// <summary>
        /// Prompts the user to enter a number corresponding to an enum value.
        /// </summary>
        /// <typeparam name="T">The enum type to validate against.</typeparam>
        /// <param name="prompt">The message displayed to the user.</param>
        /// <returns>The entered number if valid; otherwise, null.</returns>
        public static int? ReadEnum<T>(string prompt)
            where T : Enum
        {
            int maxRange = Enum.GetNames(typeof(T)).Length;

            for (int tried = 1; tried <= 3; tried++)
            {
                Console.Write(prompt);

                if (int.TryParse(Console.ReadLine(), out int number) && number >= 1 && number <= maxRange)
                {
                    return number;
                }

                ConsolePrinter.Error($"Invalid Number. Please enter a number between 1 to {maxRange}.");
                ConsolePrinter.Error($"{3 - tried} attempts remaining\n");
            }

            return null;
        }

        /// <summary>
        /// To wait until user enters key
        /// </summary>
        public static void WaitAndClear()
        {
            Console.Write("Enter any key to return to menu");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
