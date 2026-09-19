using CalculatorUtility;

namespace Calculator
{
    /// <summary>
    /// Manages the application workflow and coordinates arithmetic operations with user input.
    /// </summary>
    internal class Calculator
    {
        /// <summary>
        /// displays the menu, processes user selection, and executes the chosen calculation.
        /// </summary>
        public void ExecuteOperations()
        {
            CalculatorOptions choice;

            do
            {
                Console.WriteLine(@"=================================
1. Add Numbers.
2. Subtract Numbers.
3. Multiply Numbers.
4. Divide Numbers.
5. Exit
=================================");

                CalculatorOptions? input = UserInput.ReadEnum<CalculatorOptions>("Enter Choice: ");
                if (input == null)
                {
                    ConsolePrinter.Error("Enter a valid choice");
                    UserInput.WaitAndClear();
                    choice = default;
                    continue;
                }

                choice = (CalculatorOptions)input;

                switch (choice)
                {
                    case CalculatorOptions.Add:
                        this.Execute("+", MathUtils.Add);
                        break;

                    case CalculatorOptions.Subtract:
                        this.Execute("-", MathUtils.Subtract);
                        break;

                    case CalculatorOptions.Multiply:
                        this.Execute("*", MathUtils.Multiply);
                        break;

                    case CalculatorOptions.Divide:
                        this.Execute("/", MathUtils.Divide);
                        break;

                    case CalculatorOptions.Exit:
                        break;

                    default:
                        ConsolePrinter.Error("Enter valid choice");
                        break;
                }

                UserInput.WaitAndClear();
            }
            while (choice != CalculatorOptions.Exit);
        }

        /// <summary>
        /// To Execute appropriate operation
        /// </summary>
        /// <param name="symbol"> symbol of the operation to be performed</param>
        /// <param name="operation"> the operation to be performed</param>
        private void Execute<T>(string symbol, Func<int, int, T> operation)
        {
            int? num1 = UserInput.ReadInt("Enter first number: ");
            if (num1 == null)
            {
                ConsolePrinter.Error("Operation cancelled.");
                return;
            }

            int? num2 = UserInput.ReadInt("Enter second number: ");
            if (num2 == null)
            {
                ConsolePrinter.Error("Operation cancelled.");
                return;
            }

            try
            {
                T result = operation((int)num1, (int)num2);
                ConsolePrinter.Success($"Result: {num1} {symbol} {num2} = {result}\n");
            }
            catch (DivideByZeroException)
            {
                ConsolePrinter.Error("Error: Cannot divide by zero.\n");
            }
            catch (OverflowException)
            {
                ConsolePrinter.Error("Error: Value was not in range");
            }
        }
    }
}