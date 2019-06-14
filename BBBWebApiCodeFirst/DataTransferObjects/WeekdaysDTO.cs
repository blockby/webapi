using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.DataTransferObjects
{
    public class WeekdaysDTO
    {
        public double IdDay { get; set; }

        public String Day { get; set; }

        public String Category { get; set; }

        public int People { get; set; }
    }
}
