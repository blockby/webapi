using BBBWebApiCodeFirst.DataTransferObjects;
using BBBWebApiCodeFirst.Interfaces;
using BBBWebApiCodeFirst.Models;
using NetTopologySuite.Geometries;
using Newtonsoft.Json.Linq;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.DataReaders
{
    public class DataReader: InterfaceDataReader
    {

        public DataReader()
        {

        }

        public TopDayDTO ReadTopDayDTO(NpgsqlDataReader reader)
        {
            var obj = new JObject();

            int gid = reader.GetInt32(0);
            int id = reader.GetInt32(1);
            int daysAct = reader.GetInt32(2);            
            int zoneAct = reader.GetInt32(3);
            int people = reader.GetInt32(4);
            Geometry geom = reader.GetValue(5) as NetTopologySuite.Geometries.Geometry;

            TopDayDTO topDayDTO = new TopDayDTO
            {
                Gid = gid,
                Id = id,
                DaysAct = daysAct,                
                ZoneAct = zoneAct,
                People = people,
                Geom = geom
            };
            return topDayDTO;
        }

        public MainChartDTO ReadMainChartDTO(NpgsqlDataReader reader)
        {
            var obj = new JObject();

            int id = reader.GetInt32(0);
            int gid = reader.GetInt32(1);
            double area = reader.GetDouble(2);
            int zoneAct = reader.GetInt32(3);
            int IdDay = reader.GetInt32(4);
            string nameDay = reader.GetString(5);
            int hoursAct = reader.GetInt32(6);
            int people = reader.GetInt32(7);
            Geometry geom = reader.GetValue(8) as NetTopologySuite.Geometries.Geometry;

            MainChartDTO mainChartDTO = new MainChartDTO
            {
                Id = id,
                Gid = gid,
                Area = area,
                ZoneAct = zoneAct,
                NameDay = nameDay,
                HoursAct = hoursAct,
                People = people,
                Geom = geom
            };
            return mainChartDTO;
        }

        public TopDTO ReadTopDTO(NpgsqlDataReader reader)
        {
            int gid = reader.GetInt32(0);
            int id = reader.GetInt32(1);
            int zoneAct = reader.GetInt32(2);
            int people = reader.GetInt32(3);
            Geometry geom = reader.GetValue(4) as NetTopologySuite.Geometries.Geometry;

            TopDTO topDTO = new TopDTO
            {
                Id = id,
                ZoneAct = zoneAct,
                People = people,
                Geom = geom
            };
            return topDTO;
        }

        public TableHomeDayDTO ReadTableHomeDayDTO (NpgsqlDataReader reader)
        {
            int gid = reader.GetInt32(0);
            int id = reader.GetInt32(1);
            int zoneAct = reader.GetInt32(2);
            int daysAct = reader.GetInt32(3);
            string nameDay = reader.GetString(4);
            int hoursAct = reader.GetInt32(5);
            long countAct = reader.GetInt64(6);
            Geometry geom = reader.GetValue(3) as NetTopologySuite.Geometries.Geometry;

            TableHomeDayDTO tableHomeDayDTO = new TableHomeDayDTO
            {
                Gid = gid,
                Id = id,
                ZoneAct = zoneAct,
                DaysAct = daysAct,
                NameDay = nameDay,
                HoursAct = hoursAct,
                CountAct = countAct,
                Geom = geom
            };

            return tableHomeDayDTO;
        }

        public TableHomeWeekDTO ReadTableHomeWeekDTO(NpgsqlDataReader reader)
        {
            int gid = reader.GetInt32(0);
            int id = reader.GetInt32(1);
            int zoneAct = reader.GetInt32(2);
            int daysAct = reader.GetInt32(3);
            string nameDay = reader.GetString(4);
            long people = reader.GetInt64(5);
            Geometry geom = reader.GetValue(6) as NetTopologySuite.Geometries.Geometry;

            TableHomeWeekDTO tableHomeWeekDTO = new TableHomeWeekDTO
            {
                Gid = gid,
                Id = id,
                ZoneAct = zoneAct,
                DaysAct = daysAct,
                NameDay = nameDay,
                People = people,
                Geom = geom
            };

            return tableHomeWeekDTO;
        }

        public AreaOfInfluenceDTO ReadAreaOfInfluenceDTO(NpgsqlDataReader reader)
        {
            decimal area = reader.GetDecimal(0);

            AreaOfInfluenceDTO areaOfInfluenceDTO = new AreaOfInfluenceDTO
            {
                Area = area
            };
            return areaOfInfluenceDTO;
            
            
        }
    }
}