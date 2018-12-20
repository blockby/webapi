using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBBWebApiCodeFirst.Converters;
using BBBWebApiCodeFirst.DataReaders;
using BBBWebApiCodeFirst.DataTransferObjects;
using BBBWebApiCodeFirst.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Npgsql;

namespace BBBWebApiCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainChartController : ControllerBase
    {

        private readonly DataContext _context;
        private readonly string connectionString = "User ID = postgres; Password = postgres; Server = localhost; Port = 5432; Database = BlockDb; Integrated Security = true; Pooling = true;";

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
                        obj.Add("series",hourlyPeopleJson);
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



        //GET:api/MainChart/gettopchart1week
        [HttpGet("gettopchart1week")]

       // public IEnumerable<TopDTO> GetTopChart1Week()
       public JObject GetTopChart1Week()
        {
            string _selectString = "SELECT b.\"Id\", a.\"ZoneAct\", SUM(a.\"CountAct\") AS People, b.\"Geom\" FROM \"MtcActivitys\" a INNER JOIN \"Mtcs\" b ON a.\"ZoneAct\" = b.\"Id\" GROUP BY b.\"Id\", a.\"ZoneAct\", b.\"Geom\" ORDER BY People DESC LIMIT 5";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<TopDTO> TopDtoList = new List<TopDTO>();

                        while (reader.Read())
                        {
                            DataReader dataReader = new DataReader();
                            TopDTO topDTO = dataReader.ReadTopDTO(reader);
                            TopDtoList.Add(topDTO);
                        }


                        ObjectConverter objConverted = new ObjectConverter();

                        JObject topPeopleChart = objConverted.TopPeopleChart(TopDtoList);
                        JObject topZoneChart = objConverted.TopZoneChart(TopDtoList);

                        var obj = new JObject();

                        obj.Add("series", topPeopleChart);
                        obj.Add("labels", topZoneChart);

                        return obj;
                        //return TopDtoList;
                    }
                }
            }
        }


        //GET:api/MainChart/getminchart2week/
        [HttpGet("getminchart2week")]
        //public IEnumerable<TopDTO> GetMinChart2week()
        public JObject GetMinChart2week()
        {
            string _selectString = "SELECT b.\"Id\", a.\"ZoneAct\", SUM(a.\"CountAct\") AS People, b.\"Geom\" FROM \"MtcActivitys\" a INNER JOIN \"Mtcs\" b ON a.\"ZoneAct\" = b.\"Id\" GROUP BY b.\"Id\", a.\"ZoneAct\", b.\"Geom\" ORDER BY People ASC LIMIT 5";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<TopDTO> TopDtoList = new List<TopDTO>();

                        while (reader.Read())
                        {
                            DataReader dataReader = new DataReader();
                            TopDTO topDTO = dataReader.ReadTopDTO(reader);
                            TopDtoList.Add(topDTO);
                        }
                        ObjectConverter objConverted = new ObjectConverter();

                        JObject minPeopleChart = objConverted.MinPeopleChart(TopDtoList);
                        JObject minZoneChart = objConverted.MinZoneChart(TopDtoList);

                        var obj = new JObject();

                        obj.Add("series", minPeopleChart);
                        obj.Add("labels", minZoneChart);

                        return obj;
                    }
                }
            }
        }



        // GET: api/MainChart
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/MainChart/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/MainChart
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/MainChart/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
