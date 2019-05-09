using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.Models
{
    public class Type_user
    {
        [Key]
        public int id_type_user { get; set; }

        public string type_user { get; set; }

        public string description { get; set; }
    }
}
