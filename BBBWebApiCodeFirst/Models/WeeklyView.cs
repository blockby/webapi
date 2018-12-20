using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.Models
{
    public class WeeklyView
    {
        public int Id { get; set; }
        public int Gid { get; set; }
        public decimal Area { get; set; }
        public int ZoneAct { get; set; }
        public long People { get; set; }
        public int IdDay { get; set; }
        public string NameDay { get; set; }
        public int HoureAct { get; set; }
        


         //c.id, c.gid, c.area, a.zone_act, b.id_day, b.name_day, a.hours_act, SUM(a.count_act) AS people, c.geom
    }
}
