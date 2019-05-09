using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.Models
{
    public class Location
    {
        [Key]
        public int id_location { get; set; }

        public int id_broker { get; set; }

        public int id_type_prop { get; set; }

        public string address { get; set; }

    }
}
