using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdasFuncLINQ
{
    public class Customer
    {
        public Customer(string City, string FirstName, string LastName, int ID)
        {
            this.City = City;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.ID = ID;
        }

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }

    }
}
