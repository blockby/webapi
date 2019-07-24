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
    public class WeekendController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly string connectionString = ConnectionStringBuilder.buildConnectionString();

        public WeekendController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("getweekend")]
        public async Task<JObject> GetWeekend()
        {
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                string result = await reader.ReadToEndAsync();
                var locationObj = JObject.Parse(result)["id_location"];
                var dayTypeObj = JObject.Parse(result)["id_day_type"];
                var serviceObj = JObject.Parse(result)["id_service"];
                var rCustomerObj = JObject.Parse(result)["returning_customer"];

                string location = locationObj.ToObject<string>();
                string day_type = dayTypeObj.ToObject<string>();
                string service = serviceObj.ToObject<string>();
                string rCustomer= rCustomerObj.ToObject<string>();
                
                return ExecuteQuery(location, day_type, service, rCustomer);
            }
        }


        private JObject ExecuteQuery(string location, string day_type, string service, string rCustomer)
        {
            string _selectString = "SELECT a.id_day, b.name_day AS day COUNT(DISTINCT a.src) AS people FROM collected_data a INNER JOIN days b ON a.id_day = b.id_day WHERE a.id_location = " + location+" AND b.id_day_type = "+day_type+ " AND a.id_service = "+service+" AND a.returning_customer = " + rCustomer + "  GROUP BY a.id_day, b.id_day ORDER BY a.id_day";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<TypeDayDTO> WeekendDTOList = new List<TypeDayDTO>();

                        while (reader.Read())
                        {
                            InterfaceDataReader dataReader = new DataReader();
                            TypeDayDTO weekendDTO = dataReader.ReadTypeDayDTO(reader);
                            WeekendDTOList.Add(weekendDTO);
                        }

                        IObjectConverter objConverted = new ObjectConverter();
                        var obj = objConverted.TypeDayJson(WeekendDTOList, "Weekend");

                        return obj;
                    }
                }
            }
        }
    }
}