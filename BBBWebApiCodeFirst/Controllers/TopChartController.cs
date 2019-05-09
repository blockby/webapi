using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBBWebApiCodeFirst.Common;
using BBBWebApiCodeFirst.Converters;
using BBBWebApiCodeFirst.DataReaders;
using BBBWebApiCodeFirst.DataTransferObjects;
using BBBWebApiCodeFirst.Interfaces;
using BBBWebApiCodeFirst.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Npgsql;

namespace BBBWebApiCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopChartController
    {
        private readonly DataContext _context;
        string connectionString = ConnectionStringBuilder.buildConnectionString();

        public TopChartController(DataContext context)
        {
            _context = context;
        }

        // GET:api/TopChart/gettopchart1week
        [HttpGet("gettopchart1week")]
        public JObject GetTopChart1Week()
        {
            string _selectString = "SELECT b.id, a.zone, SUM(a.people) AS people, b.geom FROM \"MtcActivitys\" a INNER JOIN \"Mtcs\" b ON a.zone = b.id GROUP BY b.id, a.zone, b.geom ORDER BY people DESC LIMIT 5";

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
                            InterfaceDataReader idr = new DataReader();
                            TopDTO topDTO = idr.ReadTopDTO(reader);
                            TopDtoList.Add(topDTO);
                        }

                        IObjectConverter objConverted = new ObjectConverter();                                                                     
                        var obj = objConverted.TopPeopleJson(TopDtoList);
                        return obj;
                    }
                }
            }
        }


        // GET:api/TopChart/getminchart2week/
        [HttpGet("getminchart2week")]
        public JObject GetMinChart2week()
        {
            string _selectString = "SELECT b.id, a.zone, SUM(a.people) AS people, b.geom FROM \"MtcActivitys\" a INNER JOIN \"Mtcs\" b ON a.zone = b.id GROUP BY b.id, a.zone, b.geom ORDER BY people ASC LIMIT 5";

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
                            InterfaceDataReader dataReader = new DataReader();
                            TopDTO topDTO = dataReader.ReadTopDTO(reader);
                            TopDtoList.Add(topDTO);
                        }

                        IObjectConverter objConverted = new ObjectConverter();
                        var obj = objConverted.MinPeopleJson(TopDtoList);
                        return obj;
                    }
                }
            }
        }


        // GET:api/TopChart/gettopchart1day/day
        [HttpGet("gettopchart1day/{day}")]
        public JObject GetTopChart1Day([FromRoute] int day)
        {
            string _selectString = "SELECT b.id, a.day, a.zone, SUM(a.people) AS people, b.geom FROM \"MtcActivitys\" a INNER JOIN \"Mtcs\" b ON a.zone = b.id WHERE a.day = " + day + " GROUP BY b.id, a.day, a.zone, b.geom ORDER BY people DESC LIMIT 5";

            using (var conn = new NpgsqlConnection(connectionString))
            {

                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {

                        List<TopDayDTO> TopDayDtoList = new List<TopDayDTO>();

                        while (reader.Read())
                        {
                            InterfaceDataReader idr = new DataReader();
                            TopDayDTO topDayDTO = idr.ReadTopDayDTO(reader);
                            TopDayDtoList.Add(topDayDTO);
                        }

                        IObjectConverter objConverted = new ObjectConverter();
                        var obj = objConverted.TopDayPeopleJson(TopDayDtoList);
                        return obj;
                    }
                }
            }
        }


        // GET:api/TopChart/getminchart2day/day
        [HttpGet("getminchart2day/{day}")]
        public JObject GetMinChart2Day([FromRoute] int day)
        {
            string _selectString = "SELECT b.id, a.day, a.zone, SUM(a.people) AS people, b.geom FROM \"MtcActivitys\" a INNER JOIN \"Mtcs\" b ON a.zone = b.id WHERE a.day = " + day + " GROUP BY b.id, a.day, a.zone, b.geom ORDER BY people ASC LIMIT 5";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {

                        List<TopDayDTO> TopDayDtoList = new List<TopDayDTO>();

                        while (reader.Read())
                        {
                            InterfaceDataReader idr = new DataReader();
                            TopDayDTO topDayDTO = idr.ReadTopDayDTO(reader);
                            TopDayDtoList.Add(topDayDTO);
                        }

                        IObjectConverter objConverted = new ObjectConverter();
                        var obj = objConverted.TopDayPeopleJson(TopDayDtoList);
                        return obj;
                    }
                }
            }
        }

    }
}
