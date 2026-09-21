namespace MemoryManagement.Tasks
{
    /// <summary>
    /// Stack and heap memory allocations
    /// </summary>
    internal class StackAndHeap
    {
        /// <summary>
        /// Executes the Stack memory allocation and heap memory allocation
        /// </summary>
        public void ExecuteStackAndHeap()
        {
            Console.WriteLine(@"==================================================
  Managing memory on stack and heap
==================================================");

            Console.WriteLine("Heap Accumulation(List of Arrays)");
            this.CreateHeapMemory();
            Console.WriteLine("\nStack Allocation(Value Types Calculation)");
            this.CalculateValueTypes();
            UserInput.WaitAndClear();
        }

        /// <summary>
        /// Creates a list of large arrays
        /// </summary>
        public void CreateHeapMemory()
        {
            List<int[]> heapList = new List<int[]>();

            for (int i = 1; i <= 10; i++)
            {
                int[] array = new int[5_000_000];
                heapList.Add(array);
                Console.WriteLine($"Added Array {i} to the List.");
                Thread.Sleep(1000);
            }

            Console.WriteLine("Heap accumulation finished");
        }

        /// <summary>
        /// creates many values in stack memory
        /// </summary>
        private void CalculateValueTypes()
        {
            int breakfastCost = 50;
            int lunchCost = 100;
            int dinnerCost = 120;
            int snacksCost = 40;
            int teaCost = 20;

            int busFare = 30;
            int trainFare = 45;
            int autoFare = 80;
            int petrolCost = 200;
            int parkingFee = 30;

            int groceryCost = 150;
            int mobileRecharge = 100;
            int electricityBill = 500;
            int waterBill = 100;

            int totalDailyExpenses =
                breakfastCost +
                lunchCost +
                dinnerCost +
                snacksCost +
                teaCost +
                busFare +
                trainFare +
                autoFare +
                petrolCost +
                parkingFee +
                groceryCost +
                mobileRecharge +
                electricityBill +
                waterBill;

            Console.WriteLine($"Total Expenses: ₹{totalDailyExpenses}");
        }
    }
}