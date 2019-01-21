using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using BBBWebApiCodeFirst.Converters;
using BBBWebApiCodeFirst.DataReaders;
using BBBWebApiCodeFirst.DataTransferObjects;
using BBBWebApiCodeFirst.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Npgsql;
using System.IO;
using BBBWebApiCodeFirst.Common;

namespace BBBWebApiCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainChartController : ControllerBase
    {

        private readonly DataContext _context;

        string connectionString = ConnectionStringBuilder.buildConnectionString();       


        public MainChartController(DataContext context)
        {
            _context = context;
        }

        //GET:api/MainChart/getmainchartday/day/longy/lat
        [HttpGet("getmainchartday/{day}/{longy}/{lat}")]
        public JObject GetMainChartDay([FromRoute] int day, double longy, double lat)
        {
            string _pointString = "POINT(" + longy + " " + lat + ")";
            string _selectString = "SELECT c.\"Id\", c.\"Gid\", c.\"Area\", a.\"ZoneAct\", b.\"IdDay\", b.\"NameDay\", a.\"HoursAct\", SUM(a.\"CountAct\") AS People, c.\"Geom\" FROM \"MtcActivitys\" a INNER JOIN \"Dayss\" b ON a.\"DaysAct\" = b.\"IdDay\" INNER JOIN \"Mtcs\" c ON a.\"ZoneAct\" = c.\"Gid\" Where ST_Contains(c.\"Geom\", ST_GeomFromText('" + _pointString + "', 4326))=true AND a.\"DaysAct\" = " + day + " GROUP BY c.\"Id\", c.\"Gid\", a.\"ZoneAct\", b.\"IdDay\", b.\"NameDay\", a.\"HoursAct\", c.\"Geom\" ORDER BY a.\"HoursAct\" ASC";
                       
            using (var conn = new NpgsqlConnection(connectionString))
            {
                var con = conn.FullState;
              
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<MainChartDTO> mainChartDtoList = new List<MainChartDTO>();

                        while (reader.Read())
                        {
                            DataReader dataReader = new DataReader();
                            MainChartDTO mainChartDTO = dataReader.ReadMainChartDTO(reader);
                            mainChartDtoList.Add(mainChartDTO);
                        }
                        
                        ObjectConverter objConverted = new ObjectConverter();                        
                        JObject hourlyPeopleJson = objConverted.HourlyPeopleJson(mainChartDtoList);
                        JObject timeJson = objConverted.TimeJson();
                        JObject dayJson = objConverted.DayJson(mainChartDtoList);

                        var obj = new JObject();
                        obj.Add("series", hourlyPeopleJson);
                        obj.Add("labels", timeJson);
                        obj.Add("title", dayJson);

                        return obj;                        
                    }
                }
            }
        }


        //GET:api/MainChart/getmainchartweek/longy/lat
        [HttpGet("getmainchartweek/{longy}/{lat}")]
        public JObject GetMainChartWeek([FromRoute] double longy, double lat)
        {
            string _pointString = "POINT(" + longy + " " + lat + ")";

            string _selectString = "SELECT c.\"Id\", c.\"Gid\", c.\"Area\", a.\"ZoneAct\", b.\"IdDay\", b.\"NameDay\", a.\"HoursAct\", SUM(a.\"CountAct\") AS People, c.\"Geom\" FROM \"MtcActivitys\" a INNER JOIN \"Dayss\" b ON a.\"DaysAct\" = b.\"IdDay\" INNER JOIN \"Mtcs\" c ON a.\"ZoneAct\" = c.\"Gid\" Where ST_Contains(c.\"Geom\", ST_GeomFromText('" + _pointString + "', 4326))=true GROUP BY c.\"Id\", c.\"Gid\", a.\"ZoneAct\", b.\"IdDay\", b.\"NameDay\", a.\"HoursAct\", c.\"Geom\" ORDER BY a.\"HoursAct\" ASC";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<MainChartDTO> mainChartDtoList = new List<MainChartDTO>();

                        while (reader.Read())
                        {
                            DataReader dataReader = new DataReader();
                            MainChartDTO mainChartDTO = dataReader.ReadMainChartDTO(reader);
                            mainChartDtoList.Add(mainChartDTO);
                        }
                        
                        ObjectConverter objConverted = new ObjectConverter();                        
                        JObject weeklyPeopleChart = objConverted.WeeklyPeopleChart(mainChartDtoList);
                        JObject weekDayChart = objConverted.WeekDayChart();

                        var obj = new JObject();
                        obj.Add("series", weeklyPeopleChart);
                        obj.Add("labels", weekDayChart);
                        return obj;                        
                    }
                }
            }
        }       
    }
}
