using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCore.Models
{
    public class Employee
    {

        public int Id { get; set; }  //Employee_ID

        public string Name { get; set; }

        public string Department { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            return "Employee: Id = " + Id + ", Name = " + Name + ".";
        }
    }
}
