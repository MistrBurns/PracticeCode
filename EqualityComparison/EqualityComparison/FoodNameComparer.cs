using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualityComparison
{
    public class FoodNameComparer : Comparer<Food2>
    {
        public override int Compare(Food2 x, Food2 y)
        {
            if (x == null && y == null)
                return 0;
            if (x == null)
                return -1;
            if (y == null)
                return 1;
            return string.Compare(x.Name, y.Name, StringComparison.CurrentCulture);

        }
    }
}
