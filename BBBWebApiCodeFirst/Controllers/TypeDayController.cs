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
    public class TypeDayController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly string connectionString = ConnectionStringBuilder.buildConnectionString();

        public TypeDayController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("getdaybytype")]
        public async Task<JObject> GetWeekday()
        {
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                string result = await reader.ReadToEndAsync();
                
                string location = JObject.Parse(result)["id_location"].ToObject<string>();
                string dayType = JObject.Parse(result)["id_day_type"].ToObject<string>();
                string service = JObject.Parse(result)["id_service"].ToObject<string>();
                string rCustomer = JObject.Parse(result)["returning_customer"].ToObject<string>();

                return ExecuteQuery(location, dayType, service, rCustomer);
            }
        }

        private JObject ExecuteQuery(string location, string day_type, string service, string rCustomer)
        {
            string _selectString = "SELECT a.id_day AS id_day, b.name_day AS day, COUNT(DISTINCT a.src) AS people FROM collected_data a INNER JOIN days b ON a.id_day = b.id_day WHERE a.id_location = " + location+" AND a.id_day_type = "+day_type+" AND a.id_service = " + service + " AND a.returning_customer IN(" + rCustomer+ ") GROUP BY a.id_day, b.id_day ORDER BY a.id_day";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        InterfaceDataReader dataReader = new DataReader();
                        List<MainDTO> DTOList = new List<MainDTO>();
                        DTOList = dataReader.ReadMainDTO(reader);

                        IObjectConverter objConverted = new ObjectConverter();
                        var obj = objConverted.TypeDayJson(DTOList);

                        return obj;                        
                    }
                }
            }
        }

    }
}