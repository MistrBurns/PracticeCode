using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.Common;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class VendorTests
    {
        [TestMethod()]
        public void SendWelcomeEmail_ValidCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = "ABC Corp";
            var expected = "Message sent: Hello ABC Corp";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendWelcomeEmail_EmptyCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = "";
            var expected = "Message sent: Hello ";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendWelcomeEmail_NullCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = null;
            var expected = "Message sent: Hello ";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PlaceOrderTest()
        {
            //Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");
            var expected = new OperationResult(true, "Order from ABC\r\nProduct:Tools_0001\r\nQuantity: 12" +
                                                      "\r\nInstruction: standard delivery");

            //Act
            var actual = vendor.PlaceOrder(product, 12);
            //Assert
            Assert.AreEqual(expected.Success, actual.Success);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlaceOrderTest_NullProduct()
        {
            //Arrange
            var vendor = new Vendor();

            //Act
            var actual = vendor.PlaceOrder(null, 12);
            //Assert
            //Expected exception
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PlaceOrderTest_QuantityOutOfRange()
        {
            //Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Saw", " ");
            //Act
            var actual = vendor.PlaceOrder(product, 0);
            //Assert
            //Expected exception
        }
        [TestMethod()]
        public void PlaceOrderTest_3ParamsOverload()
        {
            //Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");
            var expected = new OperationResult(true, "Order from ABC\r\nProduct:Tools_0001\r\nQuantity: 12\r\nDeliver By: 25.10.2018" +
                                                      "\r\nInstruction: standard delivery");

            //Act
            var actual = vendor.PlaceOrder(product, 12,
                new DateTimeOffset(2018, 10, 25, 0, 0, 0, new TimeSpan(7, 0, 0)));
            //Assert
            Assert.AreEqual(expected.Success, actual.Success);
            Assert.AreEqual(expected.Message, actual.Message);
        }
        [TestMethod()]
        public void PlaceOrderTest_4ParamsOverload()
        {
            //Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");
            var expected = new OperationResult(true, "Order from ABC\r\nProduct:Tools_0001\r\nQuantity: 12\r\nDeliver By: 25.10.2018\r\nInstruction: Test");

            //Act
            var actual = vendor.PlaceOrder(product, 12,
                new DateTimeOffset(2018, 10, 25, 0, 0, 0, new TimeSpan(7, 0, 0)), "Test");
            //Assert
            Assert.AreEqual(expected.Success, actual.Success);
            Assert.AreEqual(expected.Message, actual.Message);
        }
        [TestMethod()]
        public void PlaceOrderTest_WithAdress()
        {
            //Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");
            var expected = new OperationResult(true, "Test with adress");
            //Act
            var actual = vendor.PlaceOrder(product, 12, Vendor.IncludeAdress.yes, Vendor.SendCopy.no);
            //Assert
            Assert.AreEqual(expected.Success, actual.Success);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod()]
        public void PlaceOrderTest_WithCopy()
        {
            //Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");
            var expected = new OperationResult(true, "Test with copy");
            //Act
            var actual = vendor.PlaceOrder(product, 10, Vendor.IncludeAdress.no, Vendor.SendCopy.yes);
            //Assert
            Assert.AreEqual(expected.Success, actual.Success);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod()]
        public void PlaceOrder_NoDeliveryDate()
        {
            //Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");
            var expected = new OperationResult(true, "Order from ABC\r\nProduct:Tools_0001\r\nQuantity: 12\r\nInstruction: Deliver fast");
            //Act
            var actual = vendor.PlaceOrder(product, 12, instructions: "Deliver fast");
            //Assert
            Assert.AreEqual(expected.Success, actual.Success);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            //Arrange
            var vendor = new Vendor();
            vendor.VendorId = 1;
            vendor.CompanyName = "ABC Corp";
            var expected = "Vendor: ABC Corp";
            //Act
            var actual = vendor.ToString();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PreprareDirectionsTest()
        {
            //Arrange
            var vendor = new Vendor();
            var expected = @"Insert \r\n to insert a new line";
            //Act
            var actual = vendor.PreprareDirections();
            Console.WriteLine(actual);
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}