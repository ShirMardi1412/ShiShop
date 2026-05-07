using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public Time InvoiceDateTime { get; set; }
        public int EmployeeID { get; set; }
        public int Hours { get; set; }
        public int Amount { get; set; }

        
        public Invoice()
        {
            this.InvoiceDateTime = new Time();
        }

        
        public Invoice(int id, Time time, int empId, int hours, int amount)
        {
            this.InvoiceID = id;
            this.InvoiceDateTime = time;
            this.EmployeeID = empId;
            this.Hours = hours;
            this.Amount = amount;
        }
    }
}
