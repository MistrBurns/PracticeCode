using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EqualityComparison;
namespace Comparer
{
    class FoodNameComparer2 : Comparer<Food2>
    {
        //implementation as singleton
        private static FoodNameComparer2 _instance = new FoodNameComparer2();

        public static FoodNameComparer2 Instance { get { return _instance; } }
        // this still cannot compare the cooking method field of cookedFood --> Comparers have a problem
        // whith inheritance!!!
        public override int Compare(Food2 x, Food2 y)
        {
            if (x == null && y == null)
                return 0;
            if (x == null)
                return -1;
            if (y == null)
                return 1;
            int nameOrder = string.Compare(x.Name, y.Name, StringComparison.CurrentCulture);
            //if the names are not equal, we already know how to sort
            if (nameOrder != 0)
                return nameOrder;
            return string.Compare(x.Group.ToString(), y.Group.ToString(), StringComparison.CurrentCulture);
        }
    }
}

