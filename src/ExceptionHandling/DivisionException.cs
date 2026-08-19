using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExceptionHandling.Helper;

namespace ExceptionHandling
{
    /// <summary>
    /// Division Exception error
    /// </summary>
    internal class DivisionException
    {
        /// <summary>
        /// Division operation
        /// </summary>
        public void Division()
        {
            try
            {
                Console.WriteLine("Enter 1st Number : ");
                double? dividend = UserInput.ReadDouble("Enter dividend: ");
                double? divisor = UserInput.ReadDouble("Enter divisor: ");
                Console.WriteLine($"the divided value is {dividend / divisor}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("division by Zero is not possible");
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid entry entered More than given tries");
            }
            finally
            {
                Console.WriteLine("Enter any key exit division calculator");
                Console.ReadKey();
            }
        }
    }
}
