using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBBWebApiCodeFirst.Common;
using BBBWebApiCodeFirst.DataReaders;
using BBBWebApiCodeFirst.DataTransferObjects;
using BBBWebApiCodeFirst.Interfaces;
using BBBWebApiCodeFirst.Models;
using BBBWebApiCodeFirst.Converters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Npgsql;

namespace BBBWebApiCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeekdaysController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly string connectionString = ConnectionStringBuilder.buildConnectionString();

        public WeekdaysController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("getweekday")]
        public async Task<JObject> GetWeekday()
        {
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                string result = await reader.ReadToEndAsync();
                var locationObj = JObject.Parse(result)["id_location"];
                var dayTypeObj = JObject.Parse(result)["id_day_type"];
                
                string location = locationObj.ToObject<string>();
                string dayType = dayTypeObj.ToObject<string>();

                return ExecuteQuery(location, dayType);
            }
        }


        private JObject ExecuteQuery(string location, string day_type)
        {
            string _selectString = "SELECT a.id_day AS id_day, b.name_day AS day, c.type_day, COUNT(DISTINCT a.src) AS people FROM collected_data a INNER JOIN days b ON a.id_day = b.id_day INNER JOIN day_types c ON c.id_type_day = b.id_day_type WHERE a.id_location = " + location+" AND b.id_day_type = "+day_type+" GROUP BY a.id_day,b.name_day, c.type_day ORDER BY a.id_day";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<WeekdaysDTO> WeekdaysDTOList = new List<WeekdaysDTO>();

                        while (reader.Read())
                        {
                            InterfaceDataReader dataReader = new DataReader();
                            WeekdaysDTO weekdaysDTO = dataReader.ReadWeekdaysDTO(reader);
                            WeekdaysDTOList.Add(weekdaysDTO);
                        }

                        IObjectConverter objConverted = new ObjectConverter();
                        var obj = objConverted.WeekdaysJson(WeekdaysDTOList);

                        return obj;
                    }
                }
            }
        }

    }
}