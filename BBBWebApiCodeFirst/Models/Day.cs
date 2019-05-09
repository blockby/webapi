using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.Models
{
    public class Day
    {
        [Key]
        public int id_day { get; set; }

        public int id_day_type { get; set; }
        [ForeignKey("id_day_type")]
        public Day_type day_type { get; set; }

        public string name_day { get; set; }

        public string description { get; set; }
    }
}
