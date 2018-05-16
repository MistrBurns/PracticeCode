using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class ProductTests
    {
        [TestMethod()]
        public void SayHelloTest()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.ProductId = 1;
            currentProduct.ProductName = "Saw";
            currentProduct.ProductDescription = "Steel saw";
            currentProduct.ProductVendor.CompanyName = "ABC Corp";
            var expected = "Hello Saw Steel saw 1" + " Available on: ";
            //Act
            var actual = currentProduct.SayHello();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ConstructorTest()
        {
            //Arrange
            var currentProduct = new Product(1, "Saw", "Steel saw");
            var expected = "Hello Saw Steel saw 1" + " Available on: ";
            //Act
            var actual = currentProduct.SayHello();
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ObjectInitializationTest()
        {
            //Arrange
            var currentProduct = new Product
            {
                ProductId = 1,
                ProductName = "Saw",
                ProductDescription = "Steel saw"
            };
            var expected = "Hello Saw Steel saw 1" + " Available on: ";
            //Act
            var actual = currentProduct.SayHello();
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Product_Null()
        {
            //Arrange
            Product currentProduct = null;
            var companyName = currentProduct?.ProductVendor?.CompanyName;
            string expected = null;
            //Act
            var actual = companyName;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ConvertMetersToInchesTest()
        {
            //Arrange
            var expected = 78.74;
            //Act
            var actual = 2 * Product.InchesPerMeter;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void MinimumPriceTest_Default()
        {
            //Arrange
            var currentProduct = new Product();
            var expected = .96m;
            //Act
            var actual = currentProduct.MinimumPrice;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void MinimumPriceTest_Bulk()
        {
            //Arrange
            var currentProduct = new Product(1, "Bulk Tools", "bulky kind of tools");
            var expected = 9.99m;
            //Act
            var actual = currentProduct.MinimumPrice;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ProductName_Format()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = " Saw     ";
            var expected = "Saw";
            //Act
            var actual = currentProduct.ProductName;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ProductName_Correct()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "Hammer";
            var expected = "Hammer";
            string expectedMessage = null;
            //Act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;
            //Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }
        [TestMethod()]
        public void ProductName_TooShort()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "aw";
            string expected = null;
            string expectedMessage = "Name must be 3-20 chars long";
            //Act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;
            //Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }
        [TestMethod()]
        public void ProductName_TooLong()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "wddddddddddddddddddddddddddddddddddddddddddddddddddd";
            string expected = null;
            string expectedMessage = "Name must be 3-20 chars long";
            //Act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;
            //Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod()]
        public void Category_DefaultValue()

        {
            //Arrange
            var currentProduct = new Product();
            string expected = "Tools";
            //Act
            var actual = currentProduct.Category;
            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void Category_NewValue()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.Category = "not Tools";
            string expected = "not Tools";
            //Act
            var actual = currentProduct.Category;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Sequence_DefaultValue()

        {
            //Arrange
            var currentProduct = new Product();
            int expected = 1;
            //Act
            var actual = currentProduct.SequenceNumber;
            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void Sequence_NewValue()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.SequenceNumber = 5;
            int expected = 5;
            //Act
            var actual = currentProduct.SequenceNumber;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ProductCode_NewValue()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.Category = "Tools";
            currentProduct.SequenceNumber = 5;
            var expected = "Tools_0005";
            //Act
            var actual = currentProduct.ProuctCode;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ProductCode_DefaultValue()
        {
            //Arrange
            var currentProduct = new Product();

            var expected = "Tools_0001";
            //Act
            var actual = currentProduct.ProuctCode;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CalculateSuggestedPriceTest()
        {
            //Arrange
            var currentProduct = new Product(1, "Saw", "");
            currentProduct.Cost = 50m;
            var expected = 55m;
            //Act
            var actual = currentProduct.CalculateSuggestedPrice(10m);
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}