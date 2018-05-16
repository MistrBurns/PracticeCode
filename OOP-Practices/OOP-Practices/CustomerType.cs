using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Practices
{
    public class CustomerType
    {
        public int CustomerTypeId { get; set; }
        public string TypeName { get; set; }
        public int? DisplayOrder { get; set; }


        public List<CustomerType> Retrieve()
        {
            var types = new List<CustomerType>
        {
            new CustomerType {CustomerTypeId = 1, TypeName = "Corporation", DisplayOrder = null },
            new CustomerType {CustomerTypeId = 2, TypeName = "Individual", DisplayOrder = null },
            new CustomerType {CustomerTypeId = 3, TypeName = "Educator", DisplayOrder = null },
            new CustomerType {CustomerTypeId = 4, TypeName = "Government", DisplayOrder = null },
        };
            return types;
        }
    }
}
