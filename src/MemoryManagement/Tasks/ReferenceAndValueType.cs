using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoryManagement.Models;

namespace MemoryManagement
{
    /// <summary>
    /// Reference and value type
    /// </summary>
    internal class ReferenceAndValueType
    {
        /// <summary>
        /// Task 1 - To Execute and Verify that The value type should remain unchanged after the method call
        /// whereas the reference type should reflect the changes made within the method.
        /// </summary>
        public void ExecuteReferenceAndValueTypes()
        {
            Console.WriteLine(@"===========================================
Reference and Value
===========================================");
            Employee employee = new Employee("Old Name", "Old Place");
            Student student = new Student("Old Name", 0);
            this.UpdateEmployee(employee);
            this.UpdateStudent(student);
            Console.WriteLine(employee.Name);
            Console.WriteLine(student.Name);
            UserInput.WaitAndClear();
        }

        /// <summary>
        /// Update the name of the Employee
        /// </summary>
        /// <param name="employee"> instance of the employee </param>
        public void UpdateEmployee(Employee employee)
        {
            employee.Name = "New Name";
        }

        /// <summary>
        /// Update the name of the student
        /// </summary>
        /// <param name="student"> instance of the student </param>
        public void UpdateStudent(Student student)
        {
            student.Name = "New Name";
        }
    }
}
