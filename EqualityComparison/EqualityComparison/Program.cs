using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualityComparison
{
    class Program
    {   /*main for value equality --> Food.cs
        static void Main(string[] args)
        {
            FoodItem banana = new FoodItem("banana", FoodGroup.Fruit);
            FoodItem banana2 = new FoodItem("banana", FoodGroup.Fruit);
            FoodItem chocolate = new FoodItem("chocolate", FoodGroup.Sweets);
            //true
            Console.WriteLine("banana == banana2 " + (banana == banana2));
            //false
            Console.WriteLine(" banana2 == chocolate " + (banana2 == chocolate));
            //false
            Console.WriteLine("chocolate == banana " + (chocolate == banana));
            //true
            Console.WriteLine("HashCode is equal for banana1&2? " + (banana.GetHashCode() == banana2.GetHashCode()));
        }*/
        //main for reference equality
        static void Main(string[] args)
        {
            Food2 apple = new Food2("apple", FoodGroup.Fruit);
            CookedFood stewedApple = new CookedFood("stewed", "apple", FoodGroup.Fruit);
            CookedFood bakedApple = new CookedFood("baked", "apple", FoodGroup.Fruit);
            CookedFood stewedApple2 = new CookedFood("stewed", "apple", FoodGroup.Fruit);
            Food2 apple2 = new Food2("apple", FoodGroup.Fruit); 

            DisplayWetherEqual(apple, stewedApple);
            DisplayWetherEqual(stewedApple, bakedApple);
            DisplayWetherEqual(stewedApple, stewedApple2);
            DisplayWetherEqual(apple, apple2);
            DisplayWetherEqual(apple, apple);
        }
        //default behavior of .net (reference equality)
        static void DisplayWetherEqual(Food2 food1, Food2 food2)
        {
            if (food1 == food2)
                Console.WriteLine(string.Format("{0,12} == {1}", food1, food2));
            else
                Console.WriteLine(string.Format("{0,12} != {1}", food1, food2));
             
            
        }
        
    }
}


