using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedConcepts.Tasks
{
    internal class Product
    {
        public Product(string name, string category, double price)
        {
            this.Name = name;
            this.Category = category;
            this.Price = price;
        }

        public string Name { get; set; }

        public string Category { get; set; }

        public double Price { get; set; }

        public override string ToString()
        {
            return $"Name: {this.Name} | Category: {this.Category} | Price: ${this.Price}";
        }
    }
}
