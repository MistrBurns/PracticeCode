using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualityComparison
{
    //Implementing equality for value types

        public enum FoodGroup { Meat, Fruit, Vegetables, Sweets }

        public struct FoodItem : IEquatable<FoodItem>
        {   
            //implementation of IEquatable<T> Equals
            public bool Equals(FoodItem other)
            {
                return this._name == other._name && this._group == other._group;
            }
            //override of object.Equals()
            public override bool Equals(object obj)
            {
                if (obj is FoodItem)
                    return Equals((FoodItem)obj);
                else
                    return false;
            }
            //implement == operator
            public static bool operator ==(FoodItem lhs, FoodItem rhs)
            {
                return lhs.Equals(rhs);
            }
            //implement != operator
            public static bool operator !=(FoodItem lhs, FoodItem rhs)
            {
                return !lhs.Equals(rhs);
            }
            //_name is string, enum is integer --> using Microfts Implementation for both
            //^ - operator is XOR
            public override int GetHashCode()
            {
                return _name.GetHashCode() ^ _group.GetHashCode();
            }

            private readonly string _name;
            private readonly FoodGroup _group;

            public string Name { get { return _name; } }
            public FoodGroup Group { get { return _group; } }

            public FoodItem(string name, FoodGroup group)
            {
                this._name = name;
                this._group = group;
            }

            public override string ToString()
            {
                return _name;
            }
        }

    }

