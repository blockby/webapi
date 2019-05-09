using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.Models
{
    public class Collected_data
    {
        [Key]
        public int id_coll_data { get; set; }

        public int id_location { get; set; }
        [ForeignKey("id_location")]
        public Location location { get; set; }

        public int id_vendor { get; set; }
        [ForeignKey("id_vendor")]
        public Vendor vendor { get; set; }

        public DateTime data_created { get; set; }

        public DateTime date_created { get; set; }

        public TimeSpan time_created { get; set; }

        public int id_day { get; set; }
        [ForeignKey("id_day")]
        public Day day { get; set; }

        public int id_day_period { get; set; }
        [ForeignKey("id_day_period")]
        public Day_period day_period { get; set; }

        public string src { get; set; }

        public string src_resolved { get; set; }

        public string dst { get; set; }

        public string subtype { get; set; }

        public int sn { get; set; }

        public string ssid { get; set; }
    }
}
