using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyUnitClassesTest
{
    [TestClass]
    public class AssertClassTest
    {
        #region AreEqual / AreNotEqual Tests 
        [TestMethod]
        [Owner("Rupom")]
        public void AreEqualTest()
        {
            string str1 = "Rupom";
            string str2 = "Rupom";

            Assert.AreEqual(str1, str2);
        }

        [TestMethod]
        [Owner("Rupom")]
        [ExpectedException(typeof(AssertFailedException))]
        public void AreEqualCaseSensativeTest()
        {
            string str1 = "Rupom";
            string str2 = "rupom";

            Assert.AreEqual(str1, str2,false);
        }

        [TestMethod]
        [Owner("Ahsan")]
        public void AreNotEqualTest()
        {
            string str1 = "Rupom";
            string str2 = "Ahsan";

            Assert.AreNotEqual(str1, str2);
        }
        #endregion
    }
}
