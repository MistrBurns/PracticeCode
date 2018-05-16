using ACM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Practices
{
    public class Invoice : ILoggable
    {
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool? IsPaid { get; set; }

        public string Log()
        {
            return InvoiceDate.ToString();
        }
    }
}
