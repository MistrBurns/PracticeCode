using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdasFuncLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var custs = new List<Customer>
            {
                new Customer("Phoenix", "John", "Doe", 1),
                new Customer("Phoenix", "Jane", "Doe", 500),
                new Customer("Seattle", "Suki", "Pizzoro", 3),
                new Customer("New York City", "Michelle", "Smith", 4)
            };

            var phxCusts = custs
                .Where(c => c.City == "Phoenix" && c.ID < 500)
                .OrderBy(c => c.FirstName);

            foreach (var cust in phxCusts)
            {
                Console.WriteLine(cust.FirstName);
            }
        }
    }
}
