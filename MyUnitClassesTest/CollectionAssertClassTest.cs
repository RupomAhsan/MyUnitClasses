using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyUnitClasses.PersonClasses;
using System.Collections.Generic;

namespace MyUnitClassesTest
{
    [TestClass]
    public class CollectionAssertClassTest
    {
        [TestMethod]
        [Owner("Rupom")]
        [Ignore()]
        public void AreCollectionsEqualFailsBecauseNoCompareTest()
        {
            PersonManager mgr = new PersonManager();

            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleExpected.Add(new Person { FirstName = "Rupom", LastName = "Ahsan" });
            peopleExpected.Add(new Person { FirstName = "Maisha", LastName = "Ashnoor" });

            peopleActual = mgr.GetPeople();

            CollectionAssert.AreEqual(peopleExpected, peopleActual);

        }

        [TestMethod]
        [Owner("Rupom")]
        public void AreCollectionsEqualWithCompareTest()
        {
            PersonManager mgr = new PersonManager();

            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleExpected.Add(new Person { FirstName = "Rupom", LastName = "Ahsan" });
            peopleExpected.Add(new Person { FirstName = "Maisha", LastName = "Ashnoor" });

            peopleActual = mgr.GetPeople();

            CollectionAssert.AreEqual(peopleExpected,
                peopleActual,
                Comparer<Person>.Create((x, y) => x.FirstName == y.FirstName && x.LastName == y.LastName ? 0 : 1));

        }

        [TestMethod]
        [Owner("Rupom")]
        public void AreCollectionsEqualTest()
        {
            PersonManager mgr = new PersonManager();

            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();
            
            peopleActual = mgr.GetPeople();
            peopleExpected = peopleActual;

            CollectionAssert.AreEqual(peopleExpected, peopleActual);

        }

        [TestMethod]
        [Owner("Rupom")]
        public void AreCollectionsEquvalentTest()
        {
            PersonManager mgr = new PersonManager();

            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleActual = mgr.GetPeople();

            peopleExpected.Add(peopleActual[0]);
            peopleExpected.Add(peopleActual[1]);

            CollectionAssert.AreEquivalent(peopleExpected, peopleActual);

        }

        [TestMethod]
        [Owner("Rupom")]
        public void IsCollectionOfTypeTest()
        {
            PersonManager mgr = new PersonManager();

            List<Person> peopleActual = new List<Person>();

            peopleActual = mgr.GetSupervisors();

            CollectionAssert.AllItemsAreInstancesOfType(peopleActual,typeof(SuperVisor));

        }
    }
}
