using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BBBWebApiCodeFirst.Converters;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;

namespace BBBWebApiCodeFirst.Models
{
    public class Mtc
    {        
        [Key]
        public long id { get; set; }

        public int groesse { get; set; }

        [JsonConverter(typeof(NetTopologySuiteConverter))]
        public Geometry geom { get; set; }
    }
}
