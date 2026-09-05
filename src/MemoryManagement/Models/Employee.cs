namespace MemoryManagement.Models
{
    /// <summary>
    /// Employee model
    /// </summary>
    internal ref struct Employee
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> struct.
        /// </summary>
        /// <param name="name"> name of the employee </param>
        /// <param name="companyName"> company name </param>
        public Employee(string name, string companyName)
        {
            this.Name = name;
            this.CompanyName = companyName;
        }

        /// <summary>
        /// Gets or Sets the Name of the Employee
        /// </summary>
        /// <value>
        /// Name of the Employee
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets the Company Name of the Employee
        /// </summary>
        /// <value>
        /// Company Name
        /// </value>
        public string CompanyName { get; set; }
    }
}
