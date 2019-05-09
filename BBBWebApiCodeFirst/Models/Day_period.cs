using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.Models
{
    public class Day_period
    {
        [Key]
        public int id_period_day { get; set; }

        public string name_period { get; set; }

        public string description { get; set; }
    }
}
