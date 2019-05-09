using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.Models
{
    public class Property_type
    {
        [Key]
        public int id_type_prop { get; set; }

        public string type_prop { get; set; }

        public string description { get; set; }

    }
}
