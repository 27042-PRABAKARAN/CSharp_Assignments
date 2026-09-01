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
            Math math = new Math(mathUtils);
            math.ExecuteOperations();
        }
    }
}