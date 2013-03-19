using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tfis.Lab.Hw.First
{
    public class Date
    {
        private int day;
        private int month;
        private int year;

        public static string[] MONTH_NAMES = new string[] 
        {
            "enero",
            "febrero",
            "marzo",
            "abril",
            "mayo",
            "junio",
            "julio",
            "agosto",
            "septiembre",
            "octubre",
            "noviembre",
            "diciembre"
        };
        
        public Date(int day, int month, int year)
        {
            ValidateDate(day, month, year);

            this.day = day;
            this.month = month;
            this.year = year;

        }

        public Date(string day, string month, string year)
        {
            int d, m, y; // Temporal holders.

            // Try parsing strings.
            if (!int.TryParse(day, out d) ||
                !int.TryParse(month, out m) ||
                !int.TryParse(year, out y))
            {
                throw new FormatException();
            }

            // Validate results.
            ValidateDate(d, m, y);

            // Assign results.
            this.day = d;
            this.month = m;
            this.year = y;
        }

        public Date()
            : this(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year)
        {
        }

        private static void ValidateDate(int day, int month, int year)
        {
            if (day < 1 || day > 31 ||
                month < 1 || month > 12 ||
                year < 1)
            {
                throw new ArgumentException();
            }
        }

        public int Day
        {
            get
            {
                return this.day;
            }

            set
            {
                ValidateDate(value, 1, 1); // Just validate day, others are constant.

                this.day = value;
            }
        }

        public int Month
        {
            get
            {
                return this.month;
            }

            set
            {
                ValidateDate(1, value, 1); // Just validate month, others are constant.

                this.month = value;
            }
        }

        public int Year
        {
            get
            {
                return this.year;
            }

            set
            {
                ValidateDate(1, 1, value); // Just validate year, others are constant.

                this.year = value;
            }
        }

        // Override to make to Date#ToString() look pretty.
        public override string ToString()
        {
            var monthName = MONTH_NAMES[this.month - 1]; // Offset to 0 - 11.

            var toString = string.Format("{0} de {1} de {2}", this.day, monthName, this.year);

            return toString;
        }

        // Required for comparitions to work properly.
        public override bool Equals(object obj)
        {
            var date = obj as Date;

            return this.day == date.Day &&
                   this.month == date.Month &&
                   this.year == date.Year;
        }

        // Just a No-Op so Visual Studio stops nagging about it.
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int Compare(Date date)
        {
            if (this.year < date.Year)
            {
                return -1;
            }
            else if(this.year > date.Year)
            {
                return 1;
            }

            if (this.month < date.Month)
            {
                return -1;
            }
            else if (this.month > date.Month)
            {
                return 1;
            }

            if (this.day < date.Day)
            {
                return -1;
            }
            else if (this.day > date.Day)
            {
                return 1;
            }

            return 0; // If reached this far, they're equal.
        }

        public static bool IsLeapYear(Date date)
        {
            var year = date.Year;

            return IsLeapYear(year);
        }

        public static bool IsLeapYear(int year)
        {
            if (year % 400 == 0)
            {
                return true;
            }
            else if (year % 100 == 0)
            {
                return false;
            }
            else if (year % 4 == 0)
            {
                return true;
            }

            return false;
        }

        public static bool IsLeapYear(string year)
        {
            int y = 0;

            if (!int.TryParse(year, out y))
            {
                throw new FormatException();
            }

            return IsLeapYear(y);
        }

        public static int GetDaysInMonth(int month)
        {
            var monthDays = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            month--;

            return monthDays[month];
        }

        public static int GetDaysInMonth(string month)
        {
            int m = 0;

            if (!MONTH_NAMES.Contains(month))
            {
                throw new KeyNotFoundException();
            }

            for (int i = 0; i < MONTH_NAMES.Length; i++)
            {
                var currentMonth = MONTH_NAMES[i];

                if (currentMonth == month)
                {
                    break; // If found it, then break.
                }

                m++; // Search for the index of month.
            }

            return GetDaysInMonth(m);
        }

        public static Date Create(int day, int month, int year)
        {
            return new Date(day, month, year);
        }
    }
}
