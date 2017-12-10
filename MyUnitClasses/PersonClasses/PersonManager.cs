using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUnitClasses.PersonClasses
{
    public class PersonManager
    {
        public Person CreatePerson(string first,
            string last,
            bool isSupervisor)
        {
            Person ret = null;

            if (!string.IsNullOrEmpty(first))
            {
                if (isSupervisor)
                    ret = new SuperVisor();
                else
                    ret = new Employee();

                //Assign Variables
                ret.FirstName = first;
                ret.LastName = last;
            }

            return ret;
        }

        public List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();

            people.Add(new Person { FirstName = "Rupom", LastName = "Ahsan" });
            people.Add(new Person { FirstName = "Maisha", LastName = "Ashnoor" });

            return people;
        }

        public List<Person> GetSupervisors()
        {
            List<Person> people = new List<Person>();

            people.Add(CreatePerson("Rupom","Ahsan",true ));
            people.Add(CreatePerson("Maisha", "Ashnoor", true));

            return people;
        }
    }
}
