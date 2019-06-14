using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.Handler
{
    public class ConverterHandler
    {
        public string getDayById(string id_day)
        {
            if (id_day == "1")
            {
                return "Monday";
            }
            if (id_day == "2")
            {
                return "Tuesday";
            }
            if (id_day == "3")
            {
                return "Wednesday";
            }
            if (id_day == "4")
            {
                return "Thursday";
            }
            if (id_day == "5")
            {
                return "Friday";
            }
            if (id_day == "6")
            {
                return "Saturday";
            }
            if (id_day == "7")
            {
                return "Sunday";
            }
            else
            {
                return null;
            }
        }
    }
}
