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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Npgsql;
using BBBWebApiCodeFirst.Converters;

namespace BBBWebApiCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllWeekByHoursController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly string connectionString = ConnectionStringBuilder.buildConnectionString();

        public AllWeekByHoursController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("getallweekbyhours")]
        public async Task<JObject> GetAllWeekByHours()
        {
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                string result = await reader.ReadToEndAsync();

                var locationObj = JObject.Parse(result)["id_location"];

                string location = locationObj.ToObject<string>();


                return ExecuteQuery(location);
            }
        }


        private JObject ExecuteQuery(string id_location)
        {
            string _selectString = "SELECT b.name_day AS day, extract(hour from a.time_created) as hour, COUNT(DISTINCT(a.src)) AS people FROM collected_data a INNER JOIN days b ON a.id_day = b.id_day WHERE a.id_location = "+id_location+" GROUP BY a.id_day,b.name_day, hour ORDER BY a.id_day,hour ASC";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<AllWeekByHoursDTO> allWeekByHoursDTOList = new List<AllWeekByHoursDTO>();

                        while (reader.Read())
                        {
                            InterfaceDataReader dataReader = new DataReader();
                            AllWeekByHoursDTO allWeekByHoursDTO = dataReader.ReadAllWeekByHoursDTO(reader);
                            allWeekByHoursDTOList.Add(allWeekByHoursDTO);
                        }

                        IObjectConverter objConverted = new ObjectConverter();
                        var obj = objConverted.AllWeekByHoursJson(allWeekByHoursDTOList);

                        return obj;
                    }
                }
            }
        }
    }
}