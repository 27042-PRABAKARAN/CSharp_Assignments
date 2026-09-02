using ExceptionHandling.Enums;

namespace ExceptionHandling
{
    /// <summary>
    /// Contains all exception handling assignment tasks.
    /// </summary>
    internal class ExceptionHandler
    {
        /// <summary>
        /// Displays the menu and allows the user to select a task.
        /// </summary>
        public void ChooseTask()
        {
            bool state = true;

            while (state)
            {
                Console.Clear();
                Console.WriteLine(@"========================================
ERROR HANDLING
========================================

TASK MENU
1. Task 1 - DivideByZeroException
2. Task 2 - IndexOutOfRangeException
3. Task 3 - Custom Exception
4. Task 4 - Global Unhandled Exception
5. Task 5 - Exception Stack Trace
6. Exit
");
                 
                int? choice = UserInput.ReadEnum<TaskList>("Enter choice: ");

                if (choice == null || !Enum.IsDefined(typeof(TaskList), choice))
                {
                    Console.WriteLine($"Please enter a number from 1 to {Enum.GetNames(typeof(TaskList)).Length}.");
                    this.Pause();
                    continue;
                }

                TaskList task = (TaskList)choice;

                switch (task)
                {
                    case TaskList.DivisionByZero:
                        this.HandleDivideByZeroException();
                        break;

                    case TaskList.IndexOutOfBound:
                        try
                        {
                            this.HandleIndexOutOfException();
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine($"NEW EXCEPTION - Exception Type : {exception.GetType().Name} Message: {exception.Message}");
                        }

                        break;

                    case TaskList.CustomException:
                        this.HandleInvalidUserException();
                        break;

                    case TaskList.GlobalUnhandledException:
                        this.ThrowUnhandledException();
                        break;

                    case TaskList.ExceptionStackTrace:
                        this.TraceStack();
                        break;

                    case TaskList.Exit:
                        state = false;
                        Console.WriteLine("Exiting application");
                        break;
                }

                this.Pause();
            }
        }

        /// <summary>
        /// Task 1: Demonstrates try, catch and finally using DivideByZeroException.
        /// </summary>
        public void HandleDivideByZeroException()
        {
            Console.Clear();
            Console.WriteLine(@"========================================
TASK 1 - DivideByZeroException
========================================");

            try
            {
                int? dividend = 10;
                Console.WriteLine($"Dividend is {dividend}");
                int? divisor = 0;
                Console.WriteLine($"Divisor is {divisor}");
                Console.WriteLine("Trying to Divide: ");
                Console.WriteLine($"Result: {dividend / divisor}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Exception Caught : Division by zero is not possible.");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Unexpected exception: {exception.Message}");
            }
            finally
            {
                Console.WriteLine("FINALLY BLOCK EXECUTED");
            }
        }

        /// <summary>
        /// Task 2: Demonstrates catching an IndexOutOfRangeException and throwing a new exception with a custom message.
        /// </summary>
        public void HandleIndexOutOfException()
        {
            Console.Clear();
            Console.WriteLine(@"========================================
TASK 2 - IndexOutOfRangeException
========================================");

            try
            {
                int[] array = { 10, 20, 30, 40 };

                Console.Write("Array elements: ");
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write(array[i] + " ");
                }

                Console.WriteLine("\nAccessing index 4");
                Console.WriteLine(array[4]);
            }
            catch (IndexOutOfRangeException exception)
            {
                Console.WriteLine($"Exception Type : {exception.GetType().Name} Message : {exception.Message}");
                throw new InvalidOperationException("Tried to access an index outside the array bounds.", exception);
            }
        }

        /// <summary>
        /// Task 3:Demonstrates creating, throwing and catching a custom InvalidUserInputException.
        /// </summary>
        public void HandleInvalidUserException()
        {
            Console.Clear();
            Console.WriteLine(@"========================================
TASK 3 - CUSTOM EXCEPTION
========================================");

            try
            {
                Console.WriteLine("Enter two integers To Divide: ");
                Console.Write("Enter dividend: ");
                if (!int.TryParse(Console.ReadLine(), out int dividend))
                {
                    throw new InvalidUserInputException("User did not enter a valid integer value.");
                }

                Console.Write("Enter divisor: ");
                if (!int.TryParse(Console.ReadLine(), out int divisor))
                {
                    throw new InvalidUserInputException("User did not enter a valid integer value.");
                }

                Console.WriteLine($"Result: {dividend / divisor}");
            }
            catch (InvalidUserInputException exception)
            {
                Console.WriteLine($"Exception Type : {exception.GetType().Name} Message : {exception.Message}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Division by zero is not possible.");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Unexpected exception: {exception.Message}");
            }
        }

        /// <summary>
        /// Task 4:
        /// Demonstrates global unhandled exception handling using AppDomain.UnhandledException.
        /// </summary>
        public void ThrowUnhandledException()
        {
            Console.Clear();
            AppDomain.CurrentDomain.UnhandledException += this.UnhandledException;
            Console.WriteLine(@"========================================
TASK 4 - GLOBAL UNHANDLED EXCEPTION
========================================");
            Console.WriteLine("Throwing an Global Unhandled Exception");
            throw new InvalidOperationException("Exception thrown - Global Unhandled Exception thrown");
        }

        /// <summary>
        /// Task 5:catching an exception and printing its stack trace.
        /// </summary>
        public void TraceStack()
        {
            Console.Clear();
            Console.WriteLine(@"======================================== 
TASK 5 - EXCEPTION STACK TRACE
========================================");
            try
            {
                throw new InvalidOperationException("Exception thrown");
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine($"Exception Type : {exception.GetType().Name} Message : {exception.Message}");
                Console.WriteLine($"STACK TRACE {exception.StackTrace}");
            }
        }

        /// <summary>
        /// Global handler for exceptions that remain unhandled.
        /// </summary>
        private void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine(@"========================================
GLOBAL UNHANDLED EXCEPTION HANDLER
========================================");
            Console.WriteLine($"IsTerminating : {e.IsTerminating}");

            if (e.ExceptionObject is Exception exception)
            {
                Console.WriteLine($"Exception Type: {exception.GetType().Name} Message : {exception.Message}");
                Console.WriteLine($"STACK TRACE {exception.StackTrace}");
            }
            else
            {
                Console.WriteLine("The unhandled object is not an Exception.");
            }

            this.Pause();
        }

        /// <summary>
        /// Pauses the console so that the task output can be viewed before returning to the menu.
        /// </summary>
        private void Pause()
        {
            Console.WriteLine("Press any key...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
