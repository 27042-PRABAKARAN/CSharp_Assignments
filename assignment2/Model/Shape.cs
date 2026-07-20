using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Model
{
    /// <summary>
    /// Shape class
    /// </summary>
    internal abstract class Shape
    {
        /// <summary>
        /// Gets or sets colour of the shape
        /// </summary>
        /// <value>
        /// Colour of the shape
        /// </value>
        protected string? Colour { get; set; }

        /// <summary>
        /// Gets or sets Area of the shape
        /// </summary>
        /// <value>
        /// Area of the shape
        /// </value>
        protected double Area { get; set; }

        /// <summary>
        /// Calculating area
        /// </summary>
        /// <returns> return the calculated area </returns>
        public abstract double CalculateArea();

        /// <summary>
        /// this prints the details
        /// </summary>
        public virtual void PrintDetails()
        {
            Console.Write($"Area is : {this.Area}, Colour is {this.Colour}\n");
        }
    }
}
