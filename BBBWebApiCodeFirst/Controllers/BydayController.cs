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

        [HttpPost("getbyday")]
        public async Task<JObject> GetByDay()
        {
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                string result = await reader.ReadToEndAsync();

                string location = JObject.Parse(result)["id_location"].ToObject<string>();
                string day = JObject.Parse(result)["id_day"].ToObject<string>();
                string service = JObject.Parse(result)["id_service"].ToObject<string>();
                string rCustomer = JObject.Parse(result)["returning_customer"].ToObject<string>();

                return ExecuteQuery(location, day, service, rCustomer);
            }            
        }
        
        private  JObject ExecuteQuery(string location, string day, string service, string rCustomer)
        {
            string _selectString = "SELECT b.name_day AS day, a.hours as hour, COUNT (DISTINCT a.src) AS people FROM collected_data a INNER JOIN days b ON a.id_day = b.id_day WHERE a.id_location = " + location + " AND a.id_day = " + day + " AND a.id_service = "+service+" AND a.returning_customer IN("+ rCustomer +") GROUP BY b.id_day, hour ORDER BY hour ASC";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        InterfaceDataReader dataReader = new DataReader();
                        List<BydayDTO> DTOList = new List<BydayDTO>();
                        DTOList = dataReader.ReadBydayDTO(reader);

                        IObjectConverter objConverted = new ObjectConverter();
                        var obj = objConverted.BydayJson(DTOList);

                        return obj;
                    }
                }
            }
        }
    }
}