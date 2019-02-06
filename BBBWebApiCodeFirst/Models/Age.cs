using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.Models
{
    public class Age
    {
        [Key]
        public int id { get; set; }

        public string range { get; set; }
    }
}
