using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualityComparison
{
    public sealed class CookedFood : Food2
    {
        private string _cookingMethod;
        public string  CookingMethod { get { return _cookingMethod; } }
        //base is calling the Base-Constructor
        public CookedFood (string cookingMethod, string name, FoodGroup group)
            : base(name, group)
        {
            this._cookingMethod = cookingMethod;            
        }
        public override string ToString()
        {
            return string.Format("{0} {1}", _cookingMethod, Name);
        }
        public override bool Equals(object obj)
        {   //base.Equals() contains most of logic
            if (!base.Equals(obj))
                return false;
            CookedFood rhs = (CookedFood)obj;
            return this._cookingMethod == rhs.CookingMethod;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode() ^ this._cookingMethod.GetHashCode();
        }
        public static bool operator ==(CookedFood x, CookedFood y)
        {
            return object.Equals(x, y);
        }
        public static bool operator !=(CookedFood x, CookedFood y)
        {
            return !object.Equals(x, y);
        }
    }
}
