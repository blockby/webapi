using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.Models
{
    public class User: IdentityUser<int>
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int id_user { get; set; }

        //public string name { get; set; }

        //public int id_user_type { get; set; }
        //[ForeignKey("id_user_type")]
        //public User_type user_type { get; set; }

        public int depend { get; set; }

        public string description { get; set; }
    }
}
