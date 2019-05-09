using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.Models
{
    public class User
    {
        [Key]
        public int id_user { get; set; }

        public string name { get; set; }

        public int id_type_user {get; set;}
        [ForeignKey("id_type_user")]
        public Type_user type_User { get; set; }

        public int depent { get; set; }

        public string description { get; set; }
    }
}
