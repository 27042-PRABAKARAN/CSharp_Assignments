using System.Runtime.CompilerServices;
using MemoryManagement.Models;

namespace Assignments
{
    /// <summary>
    /// The main entry point of the application
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            Employee employee = new Employee("Arun", "Coimbatore");
            Student student = new Student("Prabu", 20);
            this.updateEmployee(employee);
            this.updateStudent(student);
        }

        public void updateEmployee(Employee employee)
        {
            employee.Name = "New Name";
        }

        public void updateStudent(Student student)
        {
            student.Name = "New Name";
        }

    }
}