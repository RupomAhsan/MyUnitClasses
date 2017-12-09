using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace MyUnitClassesTest
{
    [TestClass]
    public class StringAssertClassTest
    {
        #region Contains / StartsWith / RegEx Tests 
        [TestMethod]
        [Owner("Rupom")]
        public void ContainsTest()
        {
            string str1 = "Rupom Ahsan";
            string str2 = "Rupom";

            StringAssert.Contains(str1, str2);
        }

        [TestMethod]
        [Owner("Rupom")]
        public void StartsWithTest()
        {
            string str1 = "Rupom Ahsan";
            string str2 = "Rupom";

            StringAssert.StartsWith(str1, str2);
        }

        [TestMethod]
        [Owner("Rupom")]
        public void IsAllLowerCaseTest()
        {
            Regex r = new Regex(@"^([^A-Z])+$");

            StringAssert.Matches("all lower case", r);
        }

        [TestMethod]
        [Owner("Rupom")]
        public void IsNotAllLowerCaseTest()
        {
            Regex r = new Regex(@"^([^A-Z])+$");

            StringAssert.DoesNotMatch("All Lower Case", r);
        }
        #endregion
    }
}
