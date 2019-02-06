using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.Models
{
    public class MtcHomezone
    {
        [Key]
        public int id { get; set; }

        public long zone { get; set; }

        [ForeignKey("zone")]
        public Mtc Mtc { get; set; }
             
        public long homezone { get; set; }

        public int day { get; set; }
        [ForeignKey("day")]
        public Day Day { get; set; }
                
        public decimal fraction { get; set; }
    }
}
