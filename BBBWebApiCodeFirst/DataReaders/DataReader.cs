using BBBWebApiCodeFirst.DataTransferObjects;
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
    public class DataReader
    {

        public DataReader()
        {

        }

        public TopDayDTO ReadTopDayDTO(NpgsqlDataReader reader)
        {
            var obj = new JObject();

            int id = reader.GetInt32(0);
            int daysAct = reader.GetInt32(1);
            string nameDay = reader.GetString(2);
            int zoneAct = reader.GetInt32(3);
            int people = reader.GetInt32(4);
            Geometry geom = reader.GetValue(5) as NetTopologySuite.Geometries.Geometry;

            TopDayDTO topDayDTO = new TopDayDTO
            {
                Id = id,
                DaysAct = daysAct,
                NameDay = nameDay,
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
            //Geometry geom = reader.GetValue(8) as NetTopologySuite.Geometries.Geometry;

            MainChartDTO mainChartDTO = new MainChartDTO
            {
                Id = id,
                Gid = gid,
                Area = area,
                ZoneAct = zoneAct,
                NameDay = nameDay,
                HoursAct = hoursAct,
                People = people,
                //Geom = geom
            };
            return mainChartDTO;
        }        
    }
}

