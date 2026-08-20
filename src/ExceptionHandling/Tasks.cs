namespace ExceptionHandling
{
    /// <summary>
    /// Division Exception error
    /// </summary>
    internal class Tasks
    {
        /// <summary>
        /// To choose a task to run
        /// </summary>
        public void ChooseTask()
        {
            Console.WriteLine("Hey User,");
            bool state = true;
            while (state)
            {
                Console.WriteLine(@"=================
1. Task - 1
2. Task - 2
3. Task - 3
4. Task - 4
5. Task - 5
6. Exit
=================
");
                int? choice = UserInput.ReadChoice("Enter choice : ");
                if (choice == null)
                {
                    Console.WriteLine("Enter Valid Input");
                    continue;
                }

                TaskList task = (TaskList)choice;
                switch (task)
                {
                    case TaskList.Task1:
                        {
                            this.Task1();
                            break;
                        }

                    case TaskList.Task2:
                        {
                            this.Task2();
                            break;
                        }

                    case TaskList.Task3:
                        {
                            this.Task3();
                            break;
                        }

                    case TaskList.Task4:
                        {
                            this.Task4();
                            break;
                        }

                    case TaskList.Task5:
                        {
                            this.Task5();
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// Division by zero exception
        /// </summary>
        public void Task1()
        {
            try
            {
                Console.WriteLine("Enter 1st Number : ");
                double? dividend = UserInput.ReadInt("Enter dividend: ");
                double? divisor = UserInput.ReadInt("Enter divisor: ");
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
                throw new Exception("Tried to access the index out of actual array");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
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
                int? dividend = UserInput.ReadInt("Enter dividend: ");
                int? divisor = UserInput.ReadInt("Enter divisor: ");
                if (dividend == null || divisor == null)
                {
                    throw new InvalidUserInputException("User did not enter proper value");
                }

                Console.WriteLine($"the divided value is {dividend / divisor}");
            }
            catch (InvalidUserInputException exception)
            {
                Console.WriteLine(exception.Message);
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

        /// <summary>
        /// Unhandled exception
        /// </summary>
        public void Task4()
        {
            AppDomain.CurrentDomain.UnhandledException += this.UnhandledException;
            Console.WriteLine("Throwing an unhandled exception...");
            throw new InvalidOperationException("Something went wrong!");
        }

        /// <summary>
        /// Unhandled exception
        /// </summary>
        public void Task5()
        {
            AppDomain.CurrentDomain.UnhandledException += this.UnhandledException;
            try
            {
                Console.WriteLine("Enter 1st Number : ");
                int? dividend = UserInput.ReadInt("Enter dividend: ");
                int? divisor = UserInput.ReadInt("Enter divisor: ");
                if (dividend == null || divisor == null)
                {
                    throw new InvalidUserInputException("User did not enter proper value");
                }

                Console.WriteLine($"the divided value is {dividend / divisor}");
            }
            catch (InvalidUserInputException)
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
                Console.WriteLine("Division operation is done");
            }

            Console.WriteLine("Throwing an unhandled exception...");
            throw new InvalidOperationException("Something went wrong!");
        }

        private void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine($"IsTerminating: {e.IsTerminating}");
            if (e.ExceptionObject is Exception exception)
            {
                Console.WriteLine($"Exception Type: {exception.GetType().Name}");
                Console.WriteLine($"Message: {exception.Message}");
                Console.WriteLine($"Stack Trace:\n{exception.StackTrace}");
            }
            else
            {
                Console.WriteLine("exception is not thrown");
            }
        }
    }
}
