using MemoryManagement.Models;

namespace MemoryManagement
{
    /// <summary>
    /// Reference and value type
    /// </summary>
    internal class ReferenceAndValueType
    {
        /// <summary>
        /// To Execute and Verify that The value type should remain unchanged after the method call
        /// whereas the reference type should reflect the changes made within the method.
        /// </summary>
        public void ExecuteReferenceAndValueTypes()
        {
            Console.WriteLine(@"===========================================
Reference and Value
===========================================");
            Employee employee = new Employee("Old Name", "Old Place");
            Student student = new Student("Old Name", 0);
            Console.WriteLine("value type before update: ", employee.Name);
            Console.WriteLine("reference type before update: " + student.Name);
            this.UpdateName(student, employee);
            Console.WriteLine("value type value is not updated : ", employee.Name);
            Console.WriteLine("reference type value is updated : " + student.Name);
            UserInput.WaitAndClear();
        }

        /// <summary>
        /// Update the name of given instance
        /// </summary>
        /// <param name="student"> instance of student </param>
        /// <param name="employee"> instance of employee </param>
        public void UpdateName(Student student, Employee employee)
        {
            student.Name = "New Name";
            employee.Name = "New Name";
        }
    }
}
