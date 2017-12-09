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
    }
}
