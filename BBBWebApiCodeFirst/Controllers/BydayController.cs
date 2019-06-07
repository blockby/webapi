using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
    public class BydayController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly string connectionString = ConnectionStringBuilder.buildConnectionString();

        public BydayController(DataContext context)
        {
            _context = context;
        }

        //[HttpGet("byday/{day}/{longy}/{lat}")]
        //public JObject Byday([FromRoute] int day, double longy, double lat)
        //{

        //    string _selectString = "SELECT day.id, day.description, act.hour, act.people, act.density FROM \"MtcActivitys\" AS act INNER JOIN \"Days\" AS day ON act.day = day.id INNER JOIN \"Mtcs\" AS zone ON act.zone = zone.id WHERE ST_Contains(zone.geom, ST_SetSRID(ST_MakePoint(" + longy + "," + lat + "), 4326)) AND act.day = " + day + " ORDER BY act.hour ASC";

        //    using (var conn = new NpgsqlConnection(connectionString))
        //    {
        //        conn.Open();

        //        using (var cmd = new NpgsqlCommand(_selectString, conn))
        //        {
        //            using (var reader = cmd.ExecuteReader())
        //            {
        //                List<MainChartDTO> mainChartDtoList = new List<MainChartDTO>();

        //                while (reader.Read())
        //                {
        //                    InterfaceDataReader dataReader = new DataReader();
        //                    MainChartDTO mainChartDTO = dataReader.ReadMainChartDTO(reader);
        //                    mainChartDtoList.Add(mainChartDTO);
        //                }

        //                ObjectConverter objConverted = new ObjectConverter();
        //                var obj = objConverted.MainChartDayJson(mainChartDtoList);

        //                return obj;
        //            }
        //        }
        //    }
        //}

        [HttpPost("getbyday")]
        public async void ReadStringDataManual()
        {
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                string result = await reader.ReadToEndAsync();
                string location = (result[9].ToString());
                string day = result[result.Length - 1].ToString();
                GetByday(location, day);                
            }
        }


        public JObject GetByday(string location, string day)
        {
            string _selectString = "SELECT b.name_day AS day, extract(hour from a.time_created) as hour, COUNT(a.src) AS people FROM collected_data a INNER JOIN days b ON a.id_day = b.id_day WHERE a.id_location = " + location + " AND a.id_day = " + day + " GROUP BY a.src, b.name_day, hour ORDER BY hour ASC";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<BydayDTO> BydayDTOList = new List<BydayDTO>();

                        while (reader.Read())
                        {
                            InterfaceDataReader dataReader = new DataReader();
                            BydayDTO bydayDTO = dataReader.ReadBydayDTO(reader);
                            BydayDTOList.Add(bydayDTO);
                        }

                        IObjectConverter objConverted = new ObjectConverter();
                        var obj = objConverted.BydayJson(BydayDTOList);

                        return obj;


                    }
                }
            }
        }
    }
}