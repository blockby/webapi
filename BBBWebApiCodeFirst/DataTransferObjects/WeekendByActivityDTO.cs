﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.DataTransferObjects
{
    public class WeekendByActivityDTO
    {
        public double IdDay { get; set; }

        public string Day { get; set; }

        public string TypeDay { get; set; }

        public string NameActivity { get; set; }

        public int People { get; set; }
    }
}
