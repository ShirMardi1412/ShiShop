using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal class Shift
    {
        public int ShiftId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int EmployCode { get; set; }
        public DateTime Entry { get; set; }

        public Shift() { }

        public Shift(int shiftId, DateTime start, DateTime end, int employCode, DateTime entry)
        {
            ShiftId = shiftId;
            Start = start;
            End = end;
            EmployCode = employCode;
            Entry = entry;
        }
    }
}
