using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.Models
{
    public class MtcAge
    {
        [Key]
        public int id { get; set; }

        public Mtc Mtc { get; set; }
        [ForeignKey("Mtc")]
        public long zone { get; set; }

        public Day Day { get; set; }
        [ForeignKey("Day")]
        public int day { get; set; }

        public int hour { get; set; }

        public Age Age { get; set; }
        [ForeignKey("Age")]
        public int age { get; set; }

        public decimal fraction { get; set; }
    }
}