using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyUnitClasses.PersonClasses;

namespace MyUnitClassesTest
{
    [TestClass]
    public class PersonManagerTest
    {
        [TestMethod]
        public void CreatePerson_OfTypeEmployeeTest()
        {
            PersonManager mgr = new PersonManager();
            Person per;

            per = mgr.CreatePerson("Rupom", "Ahsan", false);

            Assert.IsInstanceOfType(per, typeof(Employee));
        }
    }
}
