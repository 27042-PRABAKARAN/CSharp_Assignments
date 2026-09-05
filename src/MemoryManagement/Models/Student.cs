namespace MemoryManagement.Models
{
    /// <summary>
    /// Student model
    /// </summary>
    internal class Student
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Student"/> class.
        /// </summary>
        public Student()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Student"/> class.
        /// </summary>
        /// <param name="name"> name of the student </param>
        /// <param name="age"> age of the student </param>
        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        /// <summary>
        /// Gets or sets name of the student
        /// </summary>
        /// <value>
        /// Name of the student
        /// </value>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets Age of the student
        /// </summary>
        /// <value>
        /// Age of the student
        /// </value>
        public int Age { get; set; }
    }
}
