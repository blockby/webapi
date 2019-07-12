using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.DataTransferObjects
{
    public class DayByTypeDTO
    {
        public double IdDay { get; set; }
        public string Day { get; set; }
        public string Type { get; set; }
        public int People { get; set; }
    }
}
