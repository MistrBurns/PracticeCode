using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EqualityComparison;

namespace Comparer
{
    class Program
    {
        static void Main(string[] args)
        {
            Food2[] list =
            {
                new Food2("apple", FoodGroup.Fruit),
                new Food2("pear", FoodGroup.Fruit),
                new CookedFood("baked","apple", FoodGroup.Fruit)

            };
            SortAndShowList(list);
            Food2[] list2 =
            {
                new CookedFood("baked", "apple", FoodGroup.Fruit),
                new Food2("pear", FoodGroup.Fruit),
                new Food2("apple", FoodGroup.Fruit)
            };
            Console.WriteLine();
            SortAndShowList(list2);
            // This will not sort baked apple and apple, because for the Comparer, they are the same
            // --> only names are evaluated. In practice, this could confuse end-users or consumers of comparer
            // Solution in FoodNameComparer2

           
            /*
            Array.Sort(list, FoodNameComparer.Instance);
            foreach (var item in list)
                Console.WriteLine(item);*/
        }

        static void SortAndShowList(Food2[] list)
        {
            Array.Sort(list, FoodNameComparer.Instance);
            foreach (var item in list)
                Console.WriteLine(item);
        }
    }
}
