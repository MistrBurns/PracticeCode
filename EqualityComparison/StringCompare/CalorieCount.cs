using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCompare
{

    public struct CalorieCount : IComparable<CalorieCount>, IEquatable<CalorieCount>, IComparable
    {
        private float _value;
        public float Value { get { return this._value; } }

        public CalorieCount(float value)
        {
            this._value = value;
        }
        public override string ToString()
        {
            return _value + " cal";
        }

        public int CompareTo(CalorieCount other)
        {   //this makes use of the fact, that float has an implementation of CompareTo
            return this._value.CompareTo(other._value);
        }

        public static bool operator <(CalorieCount x, CalorieCount y)
        {
            return x._value < y._value;
        }

        public static bool operator <=(CalorieCount x, CalorieCount y)
        {
            return x._value <= y._value;
        }

        public static bool operator >(CalorieCount x, CalorieCount y)
        {
            return x._value > y._value;
        }

        public static bool operator >=(CalorieCount x, CalorieCount y)
        {
            return x._value >= y._value;
        }

        public static bool operator ==(CalorieCount x, CalorieCount y)
        {
            return x._value == y._value;
        }

        public static bool operator !=(CalorieCount x, CalorieCount y)
        {
            return x._value != y._value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is CalorieCount))
                return false;
            else
                return _value == ((CalorieCount)obj)._value;
        }

        public bool Equals(CalorieCount other)
        {
            return _value == other._value;
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
                throw new ArgumentException("obj");
            if (!(obj is CalorieCount))
                throw new ArgumentException("Expected CalorieCount instance", "obj");
            return CompareTo((CalorieCount)obj);
        }
    }
}
