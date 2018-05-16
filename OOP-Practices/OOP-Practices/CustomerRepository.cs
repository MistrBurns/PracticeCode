using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Practices
{
    public class CustomerRepository
    {
        public Customer Find(List<Customer> customerList, int customerId)
        {
            //LINQ query syntax
            //var query = from c
            //            in customerList
            //            where c.CustomerId == customerId
            //            select c;
            //Customer foundCustomer = query.First();

            //LINQ extension methods
            //var foundCustomer = customerList.Where(c => c.CustomerId == customerId).First();
            //c is parameter (of type Customer) --> First can be problematic, if no match is found
            var foundCustomer = customerList.FirstOrDefault(c => c.CustomerId == customerId); // default value for referencet type = null


            //finding multiple elements with same id
            //Customer foundCustomer = customerList.Where(c => c.CustomerId == customerId)
            //                                      .Skip(1)
            //                                      .FirstOrDefault();
            //return 
            return foundCustomer;
        }

        public IEnumerable<Customer> SortByName(List<Customer> customerList)
        {
            return customerList.OrderBy(c => c.LastName)
                                .ThenBy(c => c.FirstName);
        }

        public IEnumerable<Customer> SortByNameDescending(List<Customer> customerList)
        {
            return SortByName(customerList).Reverse();
        }

        public IEnumerable<Customer> SortByType(List<Customer> customerList)
        {
            return customerList.OrderByDescending(c => c.CustomerTypeId.HasValue)
                                .ThenBy(c => c.CustomerTypeId);
        }

        public IEnumerable<int> CompareSequencesIntersect()
        {
            var seq1 = Enumerable.Range(0, 10);
            var seq2 = Enumerable.Range(0, 10)
                                  .Select(i => i * i);

            return seq1.Intersect(seq2);

        }

        public IEnumerable<int> CompareSequencesExcept()
        {
            var seq1 = Enumerable.Range(0, 10);
            var seq2 = Enumerable.Range(0, 10)
                                  .Select(i => i * i);

            return seq1.Except(seq2);

        }

        //PROJECTIONS
        //morph each customer into a sequence of strings 
        public IEnumerable<string> GetNames(List<Customer> custList)
        {
            var query = custList.Select(c => c.FirstName + ", " + c.LastName);
            return query;
        }

        //creating an anonymous type --> dynamic will remove compile-time checking (Better: put this code where it is used)
        public dynamic GetNamesAndEmail(List<Customer> customerList)
        {
            var query = customerList.Select(c => new { Name = c.LastName + ", " + c.FirstName, c.EmailAdress });
            return query;
        }

        //joining without T-SQL statements
        public dynamic GetNamesAndType(List<Customer> custList, List<CustomerType> custType)
        {
            var query = custList.Join(custType
                , c => c.CustomerTypeId
                , ct => ct.CustomerTypeId
                , (c, ct) => new
                {
                    Name = c.LastName + ", " + c.FirstName,
                    CustomerTypeName = ct.TypeName
                });
            foreach (var item in query)
                Console.WriteLine(item.CustomerTypeName + " " + item.Name);
            return query;


        }

        public List<Customer> Retrieve()
        {
            InvoiceRepository invRepo = new InvoiceRepository();
            List<Customer> custList = new List<Customer>
            {new Customer() {   CustomerId = 1,
                                FirstName = "Frodo",
                                LastName = "Baggins",
                                EmailAdress = "fb@hob.me",
                                CustomerTypeId = 1,
                                InvoiceList = invRepo.Retrieve(1)},
             new Customer() {   CustomerId = 2,
                                FirstName = "Bilbo",
                                LastName = "Baggins",
                                EmailAdress = "bb@hob.me",
                                CustomerTypeId = null,
                                InvoiceList = invRepo.Retrieve(2)},
             new Customer() {   CustomerId = 3,
                                FirstName = "Samwise",
                                LastName = "Gamgee",
                                EmailAdress = "sg@hob.me",
                                CustomerTypeId = 1,
                                InvoiceList = invRepo.Retrieve(3)},
             new Customer() {   CustomerId = 4,
                                FirstName = "Rosie",
                                LastName = "Cotton",
                                EmailAdress = "rc@hob.me",
                                CustomerTypeId = 2,
                                InvoiceList = invRepo.Retrieve(4)},
            };
            return custList;
        }

        //Finding overdue customer (invoices)

        public IEnumerable<Customer> GetOverdueCustomers(List<Customer> custList)
        {
            var query = custList
                        .SelectMany(c => c.InvoiceList.Where(i => (i.IsPaid ?? false) == false), (c,i) => c).Distinct();
            return query;
        }


    }
}
