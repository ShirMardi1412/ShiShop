using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Bill
    {
        public int IdBill { get; set; }
        public bool Paid { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int EmployCode { get; set; }

        public Bill() { }

        public Bill(int idBill, bool paid, int year, int month, int employCode)
        {
            IdBill = idBill;
            Paid = paid;
            Year = year;
            Month = month;
            EmployCode = employCode;
        }

    }
}
