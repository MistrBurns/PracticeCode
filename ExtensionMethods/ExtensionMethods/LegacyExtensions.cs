using System;

namespace ExtensionMethods
{
    //class needs to be static for extension methods
    public static class LegacyExtensions
    {
        public static string ToLegacyFormat(this DateTime datetime)
        {
            return datetime.Year > 1930 ? datetime.ToString("1yyMMdd") : datetime.ToString("0yyMMdd");
         }

        public static string ToLegacyFormat(this string name)
        {
            var parts = name.ToUpper().Split(' ');
            return parts[1] + ", " + parts[0];
        }
    }
   
}
