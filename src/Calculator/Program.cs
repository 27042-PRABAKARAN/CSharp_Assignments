using CalculatorUtility;

namespace Calculator
{
    /// <summary>
    /// Program Class
    /// </summary>
    internal class Program
    {
        private static void Main()
        {
            MathUtils mathUtils = new MathUtils();
            Calculator math = new Calculator(mathUtils);
            math.ExecuteOperations();
        }
    }
}