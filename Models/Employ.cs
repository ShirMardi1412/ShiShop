using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal class Employ
    {
        public int EmployCode { get; set; }
        public string Id { get; set; }
        public string Number { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public int HourWage { get; set; }
        public bool Rank { get; set; }

        public Employ() { }

        public Employ(int employCode, string id, string number, string password, bool status, int hourWage, bool rank)
        {
            EmployCode = employCode;
            Id = id;
            Number = number;
            Password = password;
            Status = status;
            HourWage = hourWage;
            Rank = rank;
        }



    }
}
