using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.DataTransferObjects
{
    public class AllWeekByHoursDTO
    {
        public string Day { get; set; }

        public double Hour { get; set; }

        public int People { get; set; }

    }
}
