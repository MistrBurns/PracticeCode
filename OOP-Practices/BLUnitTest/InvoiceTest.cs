using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Practices;
using System.Linq;

namespace BLUnitTest
{
    [TestClass]
    public class InvoiceTest
    {
        [TestMethod]
        public void GetOverdueCustomersTest()
        {
            //Arrange
            CustomerRepository custRepo = new CustomerRepository();
            var custList = custRepo.Retrieve();
            //Act
            var query = custRepo.GetOverdueCustomers(custList);
            //Analyze
            foreach (var item in query)
            {
                Console.WriteLine(item.CustomerId + " " + item.FullName);
            }
            //Assert
            Assert.IsNotNull(query);
        }
    }
}
