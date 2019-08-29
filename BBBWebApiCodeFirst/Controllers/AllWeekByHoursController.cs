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

                string location = JObject.Parse(result)["id_location"].ToObject<string>();
                string service = JObject.Parse(result)["id_service"].ToObject<string>();
                string rCustomer = JObject.Parse(result)["returning_customer"].ToObject<string>();
                
                return ExecuteQuery(location, service, rCustomer);
            }
        }

        private JObject ExecuteQuery(string id_location, string service, string returning_customer)
        {
            string _selectString = "SELECT b.name_day AS day, a.hours as hour, COUNT(DISTINCT(a.src)) AS people FROM collected_data a INNER JOIN days b ON a.id_day = b.id_day WHERE a.id_location = "+id_location+ " AND a.id_service = " + service + " AND a.returning_customer IN(" + returning_customer + ") GROUP BY a.id_day, b.name_day, hour ORDER BY a.id_day, hour ASC";
            
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
                        var obj = objConverted.AllWeekByHoursJson(DTOList, service);

                        return obj;
                    }
                }
            }
        }
    }
}