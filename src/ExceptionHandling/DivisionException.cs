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
        /// Division by zero exception
        /// </summary>
        public void Task1()
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

        /// <summary>
        /// Array Index Out of Bound exception
        /// </summary>
        public void Task2()
        {
            try
            {
                int[] array = { 1, 2, 3, 4 };
                int index = 0;
                while (true)
                {
                    Console.WriteLine(array[index++]);
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Tried to access the index out of actual array");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
            }
            finally
            {
                Console.WriteLine("Enter any key exit Task 2");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Custom exception
        /// </summary>
        public void Task3()
        {
            try
            {
                Console.WriteLine("Enter 1st Number : ");
                double? dividend = UserInput.ReadDouble("Enter dividend: ");
                double? divisor = UserInput.ReadDouble("Enter divisor: ");
                if (dividend == null || divisor == null)
                {
                    throw new UserInputException("User did not enter proper value");
                }

                Console.WriteLine($"the divided value is {dividend / divisor}");
            }
            catch (UserInputException)
            {
                Console.WriteLine("division by Zero is not possible");
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
                Console.WriteLine("Enter any key exit Task 3");
                Console.ReadKey();
            }
        }
    }
}
