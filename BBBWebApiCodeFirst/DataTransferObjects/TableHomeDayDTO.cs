using BBBWebApiCodeFirst.Converters;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.DataTransferObjects
{
    public class TableHomeDayDTO
    {
        public int Gid { get; set; }
        public int Id { get; set; }
                    

        public int ZoneAct { get; set; }

        public int DaysAct { get; set; }

       public string NameDay { get; set; }

        public int HoursAct { get; set; }
        
        public long CountAct { get; set; }    

        [JsonConverter(typeof(NetTopologySuiteConverter))]
        public Geometry Geom { get; set; }
    }
}
