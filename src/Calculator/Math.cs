using CalculatorUtility;

namespace Calculator
{
    /// <summary>
    /// Manages the application workflow and coordinates arithmetic operations with user input.
    /// </summary>
    internal class Math
    {
        private readonly MathUtils _mathUtils;

        /// <summary>
        /// Initializes a new instance of the <see cref="Math"/> class.
        /// </summary>
        /// <param name="mathUtils"> instance of math utility</param>
        public Math(MathUtils mathUtils)
        {
            this._mathUtils = mathUtils;
        }

        /// <summary>
        /// displays the menu, processes user selection, and executes the chosen calculation.
        /// </summary>
        public void ExecuteOperations()
        {
            bool state = true;
            while (state == true)
            {
                Console.WriteLine(@"=================================
1. Add Numbers.
2. Subtract Numbers.
3, Multiply Numbers.
4. Divide Numbers.
5. Exit
=================================
");
                int? choice = UserInput.ReadChoice("Enter Choice: ");
                if (choice == null)
                {
                    ConsolePrinter.Error("Enter a valid choice");
                    continue;
                }

                switch ((CalculatorOptions)choice)
                {
                    case CalculatorOptions.Add:
                        {
                            this.Add();
                            break;
                        }

                    case CalculatorOptions.Subtract:
                        {
                            this.Subtract();
                            break;
                        }

                    case CalculatorOptions.Multiply:
                        {
                            this.Multiply();
                            break;
                        }

                    case CalculatorOptions.Divide:
                        {
                            this.Divide();
                            break;
                        }

                    case CalculatorOptions.Exit:
                        {
                            state = false;
                            break;
                        }

                    default:
                        {
                            ConsolePrinter.Error("Enter valid choice");
                            break;
                        }
                }

                UserInput.WaitAndClear();
            }
        }

        /// <summary>
        /// Computes the sum
        /// </summary>
        public void Add()
        {
            double? num1 = UserInput.ReadDouble("Enter first number: ");
            if (num1 == null)
            {
                return;
            }

            double? num2 = UserInput.ReadDouble("Enter second number: ");
            if (num2 == null)
            {
                return;
            }

            double result = this._mathUtils.Add((double)num1, (double)num2);
            Console.WriteLine($"Result: {num1} + {num2} = {result}\n");
        }

        /// <summary>
        /// Computes the difference.
        /// </summary>
        public void Subtract()
        {
            double? num1 = UserInput.ReadDouble("Enter first number: ");
            if (num1 == null)
            {
                return;
            }

            double? num2 = UserInput.ReadDouble("Enter second number: ");
            if (num2 == null)
            {
                return;
            }

            double result = this._mathUtils.Subtract((double)num1, (double)num2);
            Console.WriteLine($"Result: {num1} - {num2} = {result}\n");
        }

        /// <summary>
        /// Computes the product
        /// </summary>
        public void Multiply()
        {
            double? num1 = UserInput.ReadDouble("Enter first number: ");
            if (num1 == null)
            {
                return;
            }

            double? num2 = UserInput.ReadDouble("Enter second number: ");
            if (num2 == null)
            {
                return;
            }

            double result = this._mathUtils.Multiply((double)num1, (double)num2);
            Console.WriteLine($"Result: {num1} * {num2} = {result}\n");
        }

        /// <summary>
        /// Computes the quotient
        /// </summary>
        public void Divide()
        {
            double? num1 = UserInput.ReadDouble("Enter dividend (first number): ");
            if (num1 == null)
            {
                return;
            }

            double? num2 = UserInput.ReadDouble("Enter divisor (second number): ");
            if (num2 == null)
            {
                return;
            }

            try
            {
                double result = this._mathUtils.Divide((double)num1, (double)num2);
                Console.WriteLine($"Result: {num1} / {num2} = {result}\n");
            }
            catch (DivideByZeroException)
            {
                ConsolePrinter.Error("Error: Cannot divide by zero.\n");
            }
        }
    }
}