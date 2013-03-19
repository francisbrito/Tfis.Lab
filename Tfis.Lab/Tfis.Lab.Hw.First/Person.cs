using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tfis.Lab.Hw.First
{
    public class Person
    {
        private Date _born;

        public Person(Date born)
        {
            _born = born;
        }

        public Date Born
        {
            get
            {
                return _born;
            }
        }

        public int Age
        {
            get
            {
                // Current year - My born year = my age.
                return DateTime.Now.Year - _born.Year;
            }
        }
    }
}
