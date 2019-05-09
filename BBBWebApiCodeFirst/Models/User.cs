using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.Models
{
    public class User
    {
        [Key]
        public long id_user { get; set; }

        public string name { get; set; }

        public int id_type_user {get; set;}

        public int depent { get; set; }

        public string description { get; set; }


    

        public long zone { get; set; }
        [ForeignKey("zone")]
        public Mtc Mtc { get; set; }

        public int day { get; set; }
        [ForeignKey("day")]
        public Day Day { get; set; }

        


    }
}
