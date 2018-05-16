using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralEquality
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = { "apple", "orange", "pineapple" };
            string[] arr2 = { "apple", "pear", "pineapple" };

            //false
            Console.WriteLine(arr1 == arr2);
            //false --> arrays are reference types
            Console.WriteLine(arr1.Equals(arr2));
            //true 
            var arrayEq = (IStructuralEquatable)arr1;
            bool structEqual = arrayEq.Equals(arr2, StringComparer.Ordinal); //String comparer will compare the single elements
            Console.WriteLine(structEqual);

            var arrayCom = (IStructuralComparable)arr1;
            int structComp = arrayCom.CompareTo(arr2, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine(structComp);


        }
    }
}
