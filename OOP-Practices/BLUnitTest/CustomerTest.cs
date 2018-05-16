using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Practices;
using System.Linq;

namespace BLUnitTest
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void TestFullNameProperty()
        {
            //Arrange
            var cust = new Customer();
            cust.FirstName = "Max";
            cust.LastName = "Mustermann";
            var expected = "Max,Mustermann";
            //Act
            string actual = cust.FullName;
            //Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void FullNameFirstNameEmpty()
        {
            var cust = new Customer();
            cust.FirstName = "Max";
            var expected = "Max";
            //Act
            string actual = cust.FullName;
            //Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void FullNameLastNameEmpty()
        {
            var cust = new Customer();
            cust.LastName = "Mustermann";
            var expected = "Mustermann";
            //Act
            string actual = cust.FullName;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestContext()
        {
            //Arrange
            CustomerRepository repository = new CustomerRepository();
            var customerList = repository.Retrieve();
            //Act
            var result = repository.Find(customerList, 2);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.CustomerId);
            Assert.AreEqual("Baggins", result.LastName);
            Assert.AreEqual("Bilbo", result.FirstName);
        }

        [TestMethod]
        public void FindTestNotFound()
        {
            //Arrange
            CustomerRepository repo = new CustomerRepository();
            var customerList = repo.Retrieve();
            //Act
            var result = repo.Find(customerList, 42);
            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SortByNameTest()
        {
            //Arrange
            CustomerRepository repo = new CustomerRepository();
            var customerList = repo.Retrieve();
            //Act
            var result = repo.SortByName(customerList);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.First().CustomerId);
            Assert.AreEqual("Bilbo", result.First().FirstName);
            Assert.AreEqual("Baggins", result.First().LastName);
        }

        [TestMethod]
        public void SortByNameDescendingTest()
        {
            //Arrange
            CustomerRepository repo = new CustomerRepository();
            var customerList = repo.Retrieve();
            //Act
            var result = repo.SortByName(customerList);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Last().CustomerId);
            Assert.AreEqual("Samwise", result.Last().FirstName);
            Assert.AreEqual("Gamgee", result.Last().LastName);
        }

        [TestMethod]
        public void SortByType()
        {
            //Arrange
            CustomerRepository repo = new CustomerRepository();
            var customerList = repo.Retrieve();
            //Act
            var result = repo.SortByType(customerList);
            //Assert
            Assert.AreEqual(null, result.Last().CustomerTypeId);
        }

        [TestMethod]
        public void GetNamesTest()
        {
            //Arrange
            CustomerRepository repo = new CustomerRepository();
            var customerList = repo.Retrieve();
            //Act
            var query = repo.GetNames(customerList);
            //Analyze
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
            //Assert
            Assert.IsNotNull(query);
        }

        [TestMethod]
        public void GetNamesAndTypeJoinTest()
        {
            //Arrange
            CustomerRepository repo = new CustomerRepository();
            var customerList = repo.Retrieve();

            CustomerType type = new CustomerType();
            var customerTypeList = type.Retrieve();
            //Act
            var query = repo.GetNamesAndType(customerList, customerTypeList);
            //Analyze
            
           //Not a test method
        }


    }
}
