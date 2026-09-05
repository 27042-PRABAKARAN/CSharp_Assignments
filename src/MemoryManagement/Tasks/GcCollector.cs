using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoryManagement.Models;

namespace MemoryManagement.Tasks
{
    /// <summary>
    /// Forcing garbage collector to remove unreferenced objects
    /// </summary>
    internal class GcCollector
    {
        private readonly List<Student> _students = new ();

        /// <summary>
        /// Force executes garbage collector
        /// </summary>
        public void ExecuteGarbageCollected()
        {
            Process currentProcess = Process.GetCurrentProcess();
            Console.WriteLine($"Initial Managed Memory: {GC.GetTotalMemory(false) / 1024 / 1024:F2} MB");
            for (int i = 0; i < 100_000; i++)
            {
                Student student = new Student();
                if (i % 5000 == 0)
                {
                    this._students.Add(student);
                }

                if (i != 0 && i % 10000 == 0)
                {
                    Console.WriteLine($"Forcing GC at iteration {i}");
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    currentProcess.Refresh();
                    Console.WriteLine($"Working Set: {currentProcess.WorkingSet64 / 1024 / 1024:F2} MB");
                }
            }

            Console.ReadLine();
        }
    }
}
