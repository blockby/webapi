using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.Models
{
    public class Shared_location
    {
        [Key]
        public int id_sh_location { get; set; }

        public int id_user { get; set; }

        public int id_location { get; set; }
        [ForeignKey("id_location")]
        public Location location { get; set; }

        public bool state { get; set; }
    }
}
