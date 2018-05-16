using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExtensionMethods;

namespace LegacyExtensionsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ToLegacyFormat_Test()
        {
            var datetime = new DateTime(1920, 12, 31);
            Assert.AreEqual("0201231", datetime.ToLegacyFormat());
        }
        [TestMethod]
        public void ToLegacyName_Test()
        {
            string name = "Max Mustermann";
            string name_exp = "MUSTERMANN, MAX";
            Assert.AreEqual(name_exp, name.ToLegacyFormat());
            
        }
    }
}
