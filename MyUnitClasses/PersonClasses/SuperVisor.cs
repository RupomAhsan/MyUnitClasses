using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUnitClasses.PersonClasses
{
    public class SuperVisor:Person
    {
        public List<Employee> Employees { get; set; }
    }
}
