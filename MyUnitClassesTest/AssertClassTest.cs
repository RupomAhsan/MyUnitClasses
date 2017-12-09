using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyUnitClasses;
using MyUnitClasses.PersonClasses;

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

        #region AreSame / AreNotSame Tests 
        [TestMethod]
        [Owner("Rupom")]
        public void AreSameTest()
        {
            FileProcess x = new FileProcess();
            FileProcess y = x;

            Assert.AreSame(x, y);
        }        

        [TestMethod]
        [Owner("Ahsan")]
        public void AreNotSameTest()
        {
            FileProcess x = new FileProcess();
            FileProcess y = new FileProcess();

            Assert.AreNotSame(x, y);
        }
        #endregion

        #region IsInstanceOfType Tests 
        [TestMethod]
        [Owner("Rupom")]
        public void IsInstanceOfTypeTest()
        {
            PersonManager mgr = new PersonManager();
            Person per;

            per = mgr.CreatePerson("Rupom", "Ahsan", true);

            Assert.IsInstanceOfType(per, typeof(SuperVisor));
        }
        #endregion

        #region IsNull Tests 
        [TestMethod]
        [Owner("Rupom")]
        public void IsNullTest()
        {
            PersonManager mgr = new PersonManager();
            Person per;

            per = mgr.CreatePerson("", "Ahsan", true);

            Assert.IsNull(per);
        }
        #endregion
    }
}
