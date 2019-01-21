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
        public int IdAge { get; set; }

        public Mtc Mtc { get; set; }
        [ForeignKey("Mtc")]
        public int ZoneAge { get; set; }


        public long AgeAge { get; set; }
        public int HoursAge { get; set; }


        public Days Days { get; set; }
        [ForeignKey("Days")]
        public int DaysAge { get; set; }

        public decimal ShareAge { get; set; }
    }
}