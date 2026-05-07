using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Time
    {
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
        public int hour { get; set; }
        public int minute { get; set; }


        public Time() { }

        public void ConvertIntToTime(int year, int month, int day, int hour, int minute)
        {

            if (month >= 1 && month <= 12 && day <= 31 && day >= 1 && hour <= 24 && hour >= 0 && minute >= 0 && minute <= 60)
            {
                this.year = year;
                this.month = month;
                this.day = day;
                this.hour = hour;
                this.minute = minute;
            }
            else
            {
                throw new Exception("Invalid Arguments");
            }



        }
    }
}