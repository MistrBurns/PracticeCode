using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCompare
{
    class Program
    {
        static void Main(string[] args)
        {   /*
            string apple = "apple";
            string pear = "pear";
            // this are the interface methods
            //-1
            Console.WriteLine(apple.CompareTo(pear));
            //1
            Console.WriteLine(pear.CompareTo(apple));
            //0
            Console.WriteLine(apple.CompareTo(apple));
            DisplayOrder(apple, pear);
            DisplayOrder(pear, apple);
            DisplayOrder(apple, apple);

            DisplayOrder(3, 4);
            DisplayOrder(4, 3);
            DisplayOrder(4, 4);
            */
            CalorieCount cal300 = new CalorieCount(300);
            CalorieCount cal400 = new CalorieCount(400);

            DisplayOrder(cal300, cal400);
            DisplayOrder(cal400, cal300);
            DisplayOrder(cal300, cal300);

        }

        static void DisplayOrder<T>(T x, T y) where T : IComparable<T>
        {
            int result = x.CompareTo(y);
            if (result == 0)
                Console.WriteLine("{0,12} = {1}", x, y);
            else if (result > 0)
                Console.WriteLine("{0,12} > {1}", x, y);
            else
                Console.WriteLine("{0,12} < {1}", x, y);
        }
    }
}
