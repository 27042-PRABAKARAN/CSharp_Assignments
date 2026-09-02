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

            Console.WriteLine(@"========================================
ERROR HANDLING
========================================");

            while (state)
            {
                Console.WriteLine(@"
TASK MENU
1. Task 1 - DivideByZeroException
2. Task 2 - IndexOutOfRangeException
3. Task 3 - Custom Exception
4. Task 4 - Global Unhandled Exception
5. Task 5 - Exception Stack Trace
6. Exit
");

                int? choice = UserInput.ReadChoice("Enter choice: ");

                if (choice == null || !Enum.IsDefined(typeof(TaskList), choice))
                {
                    Console.WriteLine($"Please enter a number from 1 to {Enum.GetNames(typeof(TaskList)).Length}.");
                    UserInput.WaitAndClear();
                    continue;
                }

                TaskList task = (TaskList)choice;

                switch (task)
                {
                    case TaskList.Task1:
                        this.HandleDivideByZeroException();
                        break;

                    case TaskList.Task2:
                        try
                        {
                            this.HandleIndexOutOfException();
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine($"CUSTOM EXXCEPTION - Exception Type : {exception.GetType().Name} Message: {exception.Message}");
                        }

                        this.Pause();
                        break;

                    case TaskList.Task3:
                        this.HandleInvalidUserException();
                        break;

                    case TaskList.Task4:
                        this.ThrowUnhandledException();
                        break;

                    case TaskList.Task5:
                        this.TraceStack();
                        break;

                    case TaskList.Exit:
                        state = false;
                        Console.WriteLine("Exiting application");
                        break;
                }

                UserInput.WaitAndClear();
            }
        }

        /// <summary>
        /// Task 1: Demonstrates try, catch and finally using DivideByZeroException.
        /// </summary>
        public void HandleDivideByZeroException()
        {
            Console.WriteLine(@"========================================
TASK 1 - DivideByZeroException
========================================");

            try
            {
                int? dividend = UserInput.ReadInt("Enter dividend: ");

                int? divisor = UserInput.ReadInt("Enter divisor: ");

                Console.WriteLine($"Result: {dividend / divisor}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Division by zero is not possible.");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Unexpected exception: {exception.Message}");
            }
            finally
            {
                Console.WriteLine("FINALLY BLOCK EXECUTED");
            }

            this.Pause();
        }

        /// <summary>
        /// Task 2: Demonstrates catching an IndexOutOfRangeException and throwing a new exception with a custom message.
        /// </summary>
        public void HandleIndexOutOfException()
        {
            Console.WriteLine(@"========================================
TASK 2 - IndexOutOfRangeException
========================================");

            try
            {
                int[] array = { 10, 20, 30, 40 };

                Console.WriteLine("Array elements:");
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write(array[i] + " ");
                }

                Console.WriteLine("Accessing index 4");
                Console.WriteLine(array[4]);
            }
            catch (IndexOutOfRangeException exception)
            {
                Console.WriteLine($"Exception Type : {exception.GetType().Name} Message : {exception.Message}");
                throw new Exception("Tried to access an index outside the array bounds.", exception);
            }
        }

        /// <summary>
        /// Task 3:Demonstrates creating, throwing and catching a custom InvalidUserInputException.
        /// </summary>
        public void HandleInvalidUserException()
        {
            Console.WriteLine(@"========================================
TASK 3 - CUSTOM EXCEPTION
========================================");

            try
            {
                Console.WriteLine("Enter two integers.");
                int? dividend = UserInput.ReadInt("Enter dividend: ");
                int? divisor = UserInput.ReadInt("Enter divisor: ");
                if (dividend == null || divisor == null)
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

            this.Pause();
        }

        /// <summary>
        /// Task 4:
        /// Demonstrates global unhandled exception handling using AppDomain.UnhandledException.
        /// </summary>
        public void ThrowUnhandledException()
        {
            AppDomain.CurrentDomain.UnhandledException += this.UnhandledException;
            Console.WriteLine(@"========================================
TASK 4 - GLOBAL UNHANDLED EXCEPTION
========================================");
            throw new InvalidOperationException("Exception thrown");
        }

        /// <summary>
        /// Task 5:catching an exception and printing its stack trace.
        /// </summary>
        public void TraceStack()
        {
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

            this.Pause();
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
        }

        /// <summary>
        /// Pauses the console so that the task output can be viewed before returning to the menu.
        /// </summary>
        private void Pause()
        {
            Console.WriteLine("Press any key to return to the task menu...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
