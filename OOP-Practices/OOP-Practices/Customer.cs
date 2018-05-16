using ACM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Practices
{
    public class Customer : ILoggable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        private string fullName;
        public string FullName
        {
            get
            {
                string fullName = FirstName;
                if (!String.IsNullOrWhiteSpace(LastName))
                {
                    if (!String.IsNullOrWhiteSpace(FirstName))
                    {
                        fullName += ",";
                    }
                    fullName += LastName;
                }
                return fullName;
            }
        }
        
        public string  EmailAdress { get; set; }
        public int CustomerId { get; set; }
        public int? CustomerTypeId { get; set; }
        public List<Invoice> InvoiceList { get; set; }

        public string Log()
        {
            var logString = $"{this.CustomerId}: {this.FullName} Email {this.EmailAdress}";
            return logString;
        }

    }
}
