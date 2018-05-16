using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EqualityComparison;

namespace EqualityComparer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Goal is creating a set with FoodItems (structs) and each item is in the set only once
            // --> use HashSet instead of List --> HashSet only can have eatch item once
            var foodItems = new HashSet<FoodItem>(FoodItemEqualityComparer.Instance);
            foodItems.Add(new FoodItem("apple", FoodGroup.Fruit));
            foodItems.Add(new FoodItem("pear", FoodGroup.Fruit));
            foodItems.Add(new FoodItem("pineapple", FoodGroup.Fruit));
            foodItems.Add(new FoodItem("Apple", FoodGroup.Fruit));
            //
            foreach (var item in foodItems)
                Console.WriteLine(item);
        }
    }
}
