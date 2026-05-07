using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Password { get; set; }
        public string NationalID { get; set; }
        public bool IsManager { get; set; }
        public string PhoneNumber { get; set; }
        public int HourRage { get; set; }
        public bool IsActivie { get; set; }




        public Employee() { }

        public Employee(int employeeID, string password, string nationalID, bool isManager, string phoneNumber, int hourRage, bool isActivie)
        {
            EmployeeID = employeeID;
            Password = password;
            NationalID = nationalID;
            IsManager = isManager;
            PhoneNumber = phoneNumber;
            HourRage = hourRage;
            IsActivie = isActivie;
        }


    }
}
