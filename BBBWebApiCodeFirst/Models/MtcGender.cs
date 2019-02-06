using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.Models
{
    public class MtcGender
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

        public Gender Gender { get; set; }
        [ForeignKey("Gender")]
        public long gender { get; set; }
        
        public decimal fraction { get; set; }
    }
}
