using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.Models
{
    public class Vendor
    {
        [Key]
        public int id_vendor { get; set; }

        public string name_vendor { get; set; }

        public string description { get; set; }
    }
}
