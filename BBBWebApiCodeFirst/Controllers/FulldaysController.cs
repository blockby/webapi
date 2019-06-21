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
    public class FulldaysController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly string connectionString = ConnectionStringBuilder.buildConnectionString();

        public FulldaysController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("getfulldays")]
        public async Task<JObject> GetFullDays()
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
            string _selectString = "SELECT a.id_day, b.name_day AS day, COUNT(DISTINCT a.src) AS people FROM collected_data a INNER JOIN days b ON a.id_day = b.id_day WHERE a.id_location = " + id_location+" GROUP BY a.id_day,b.name_day ORDER BY a.id_day";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<FullDaysDTO> FulldaysDTOList = new List<FullDaysDTO>();

                        while (reader.Read())
                        {
                            InterfaceDataReader dataReader = new DataReader();
                            FullDaysDTO fulldaysDTO = dataReader.ReadFulldaysDTO(reader);
                            FulldaysDTOList.Add(fulldaysDTO);
                        }

                        IObjectConverter objConverted = new ObjectConverter();
                        var obj = objConverted.FulldaysJson(FulldaysDTOList);

                        return obj;
                    }
                }
            }
        }
    }
}