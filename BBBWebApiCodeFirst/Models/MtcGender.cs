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
        public int IdGen { get; set; }

        public Mtc Mtc { get; set; }
        [ForeignKey("Mtc")]
        public int ZoneGen { get; set; }


        public long GenderGen { get; set; }
        public int HoursGen { get; set; }


        public Days Days { get; set; }
        [ForeignKey("Days")]
        public int DaysGen { get; set; }

        public decimal ShareGen { get; set; }
    }
}
