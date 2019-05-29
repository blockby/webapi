using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using BBBWebApiCodeFirst.Converters;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;

namespace BBBWebApiCodeFirst.Models
{
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_location { get; set; }

        public int id_user { get; set; }
        [ForeignKey("id_user")]
        public User user { get; set; }

        public int id_prop_type { get; set; }
        [ForeignKey("id_prop_type")]
        public Property_type property_type { get; set; }

        public string address { get; set; }

        [JsonConverter(typeof(NetTopologySuiteConverter))]
        public Point coordinates { get; set; }
    }
}
