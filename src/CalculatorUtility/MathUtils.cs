namespace CalculatorUtility
{
    /// <summary>
    /// Provides standard mathematical operations for basic arithmetic calculations.
    /// </summary>
    public class MathUtils
    {
        /// <summary>
        /// Adds two numbers together.
        /// </summary>
        /// <param name="firstNumber">The first value to add.</param>
        /// <param name="secondNumber">The second value to add.</param>
        /// <returns>The sum of the two numbers.</returns>
        public int Add(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }

        /// <summary>
        /// Subtracts the second number from the first number.
        /// </summary>
        /// <param name="firstNumber">The base value.</param>
        /// <param name="secondNumber">The value to subtract from the base value.</param>
        /// <returns>The difference between the two numbers.</returns>
        public int Subtract(int firstNumber, int secondNumber)
        {
            return firstNumber - secondNumber;
        }

        /// <summary>
        /// Multiplies two numbers together.
        /// </summary>
        /// <param name="firstNumber">The first value to multiply.</param>
        /// <param name="secondNumber">The second value to multiply.</param>
        /// <returns>The product of the two numbers.</returns>
        public int Multiply(int firstNumber, int secondNumber)
        {
            return firstNumber * secondNumber;
        }

        /// <summary>
        /// Divides the first number by the second number.
        /// </summary>
        /// <param name="firstNumber">The number to be divided (dividend).</param>
        /// <param name="secondNumber">The number to divide by (divisor).</param>
        /// <returns>The result of the division.</returns>
        /// <exception cref="DivideByZeroException">Thrown when the second number is zero.</exception>
        public int Divide(int firstNumber, int secondNumber)
        {
            if (secondNumber == 0)
            {
                throw new DivideByZeroException();
            }

            return firstNumber / secondNumber;
        }
    }
}