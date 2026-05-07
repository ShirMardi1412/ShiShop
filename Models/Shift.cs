using System;

namespace Models
{
    public class Shift
    {
        public enum ShiftType
        {
            Morning,
            Evening
        }

        public int ShiftId { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int EmployCode { get; set; }
        public ShiftType Type { get; set; } // Re-added the Enum property

        public Shift() { }

        public Shift(int shiftId, DateTime start, DateTime end, int employCode, DateTime dateTime, ShiftType type)
        {
            ShiftId = shiftId;
            DateTime = dateTime;
            Start = start;
            End = end;
            EmployCode = employCode;
            Type = type;
        }
    }
}