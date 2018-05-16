using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualityComparison
{
    //implementing equality for reference types
    public class Food2 
    {
        private readonly string _name;
        private readonly FoodGroup _group;

        public string Name { get { return _name; } }
        public FoodGroup Group { get { return _group; } }

        public Food2(string name, FoodGroup group)
        {
            this._name = name;
            this._group = group;
        }
        public override string ToString()
        {
            return string.Format("{0} {1}", _name, _group); 
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (ReferenceEquals(obj, this))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            Food2 rhs = obj as Food2;
            return this._name == rhs._name && this._group == rhs._group;
        }
        public override int GetHashCode()
        {
            return this._name.GetHashCode() ^ this._group.GetHashCode();
        }
        public static bool operator ==(Food2 x, Food2 y)
        {
            //static method will check for null and then call virtual Equals()
            return object.Equals(x, y); 
        }
        public static bool operator !=(Food2 x, Food2 y)
        {
            return !object.Equals(x, y);
        }
    }
}
