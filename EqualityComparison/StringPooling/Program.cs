using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPooling
{
    class Program
    {
        static void Main(string[] args)
        {
            string apple1 = "Apple";
            string apple2 = "Ap" + "ple";

            Console.WriteLine(string.Format("Strings are {0} and {1}", apple1, apple2));

            Console.WriteLine(apple1 == apple2);
            Console.WriteLine(ReferenceEquals(apple1, apple2));
        }
    }
}
