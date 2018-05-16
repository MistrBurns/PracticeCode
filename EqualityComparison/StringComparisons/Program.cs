using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StringComparisons
{
    class Program
    {
        static void Main(string[] args)
        {
            // -4 => is less than 0 --> lemon < lime
            Console.WriteLine(string.Compare("apple", "Apple", StringComparison.Ordinal));

            Console.WriteLine("Current culture is " + Thread.CurrentThread.CurrentCulture);
            // U+00DF is ß
            DisplayAllComparisons("Strasse", "Stra\u00dfe");
            //ä= U+00E4
            string str1 = "erkl\u00e4ren";
            //a+" = U+0308
            string str2 = "erkla\u0308ren";
            DisplayAllComparisons(str1, str2);
        }


        static void DisplayAllComparisons(string str1, string str2)
        {
            DisplayComparison(str1, str2, StringComparison.Ordinal);
            DisplayComparison(str1, str2, StringComparison.OrdinalIgnoreCase);
            Console.WriteLine();
            DisplayComparison(str1, str2, StringComparison.InvariantCulture);
            DisplayComparison(str1, str2, StringComparison.InvariantCultureIgnoreCase);
            Console.WriteLine();
            DisplayComparison(str1, str2, StringComparison.CurrentCulture);
            DisplayComparison(str1, str2, StringComparison.CurrentCultureIgnoreCase);
            Console.WriteLine();
        }

        static void DisplayComparison(string str1, string str2, StringComparison comparison)
        {
            int result = string.Compare(str1, str2, comparison);
            Console.WriteLine("{0} {1} {2}   ({3}), {4})", str1, GetCompareSymbol(result), str2, result, comparison);
        }
        static string GetCompareSymbol(int compareResult)
        {
            if (compareResult == 0)
                return "==";
            else if (compareResult < 0)
                return "<";
            else
                return ">";
        }
    }
}
