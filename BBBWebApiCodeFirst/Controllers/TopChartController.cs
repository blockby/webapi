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
            string _selectString = "SELECT b.\"Gid\", b.\"Id\", a.\"ZoneAct\", SUM(a.\"CountAct\") AS People, b.\"Geom\" FROM \"MtcActivitys\" a INNER JOIN \"Mtcs\" b ON a.\"ZoneAct\" = b.\"Id\" GROUP BY b.\"Gid\", b.\"Id\", a.\"ZoneAct\", b.\"Geom\" ORDER BY People DESC LIMIT 5";

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
            string _selectString = "SELECT  b.\"Gid\", b.\"Id\", a.\"ZoneAct\", SUM(a.\"CountAct\") AS People, b.\"Geom\" FROM \"MtcActivitys\" a INNER JOIN \"Mtcs\" b ON a.\"ZoneAct\" = b.\"Id\" GROUP BY b.\"Gid\", b.\"Id\", a.\"ZoneAct\", b.\"Geom\" ORDER BY People ASC LIMIT 5";

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

        // GET:api/TopChart/gettopchart1day
        [HttpGet("gettopchart1day")]
        public JObject GetTopChart1Day()
        {
            string _selectString = "SELECT  b.\"Gid\", b.\"Id\", a.\"DaysAct\", a.\"ZoneAct\", SUM(a.\"CountAct\") AS people, b.\"Geom\" FROM \"MtcActivitys\" a INNER JOIN \"Mtcs\" b ON a.\"ZoneAct\" = b.\"Gid\" WHERE a.\"DaysAct\" = 1 GROUP BY b.\"Gid\", b.\"Id\", a.\"DaysAct\", a.\"ZoneAct\", b.\"Geom\" ORDER BY people DESC LIMIT 5";

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
