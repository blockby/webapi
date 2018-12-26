using BBBWebApiCodeFirst.Converters;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.DataTransferObjects
{
    public class TopDTO
    {
        public int Id { get; set; }

        public int ZoneAct { get; set; }

        public int People { get; set; }

        [JsonConverter(typeof(NetTopologySuiteConverter))]
        public Geometry Geom { get; set; }
    }
}
