﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.DataTransferObjects
{
    public class BydayDTO
    {
        private string _day;
        private int _hour;
        private int _people;

        public string Day { get { return _day; } set { _day = value; } }
        public int Hour { get { return _hour; } set { _hour = value; } }
        public int People { get { return _people; } set { _people = value; } }

        public BydayDTO() {

        }

        public BydayDTO(string day, int hour, int people)
        {
            _day = day;
            _hour = hour;
            _people = people;
        }
    }
}
