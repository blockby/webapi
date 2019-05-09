using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.Models
{
    public class Day_type
    {
        [Key]
        public int id_type_day { get; set; }

        public string type_day { get; set; }

        public string description { get; set; }
    }
}
