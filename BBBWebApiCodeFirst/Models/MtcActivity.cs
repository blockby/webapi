using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.Models
{
    public class MtcActivity
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

        public int people { get; set; }       

        public decimal? density { get; set; }
    }
}
