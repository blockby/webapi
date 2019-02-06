using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.Models
{
    public class Gender
    {
        [Key]
        public int id { get; set; }

        public string description { get; set; }
    }
}
