﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.DataTransferObjects
{
    public class WeekdaysDTO
    {
        public double IdDay { get; set; }

        public string Day { get; set; }

        public string Category { get; set; }

        public int People { get; set; }
    }
}
