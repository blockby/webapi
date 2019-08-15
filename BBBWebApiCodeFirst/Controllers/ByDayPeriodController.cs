using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBBWebApiCodeFirst.Common;
using BBBWebApiCodeFirst.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Npgsql;
using BBBWebApiCodeFirst.DataTransferObjects;
using BBBWebApiCodeFirst.Interfaces;
using BBBWebApiCodeFirst.DataReaders;
using BBBWebApiCodeFirst.Converters;

namespace BBBWebApiCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ByDayPeriodController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly string connectionString = ConnectionStringBuilder.buildConnectionString();

        private string _selectString;

        public ByDayPeriodController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("getbydayperiod")]
        public async Task<JObject> GetByDayPeriod()
        {
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                string result = await reader.ReadToEndAsync();
                
                string location = JObject.Parse(result)["id_location"].ToObject<string>();
                string day = JObject.Parse(result)["id_day"].ToObject<string>();
                string dayPeriod = JObject.Parse(result)["id_day_period"].ToObject<string>();
                string service = JObject.Parse(result)["id_service"].ToObject<string>();
                string rCustomer = JObject.Parse(result)["returning_customer"].ToObject<string>();

                return ExecuteQuery(location, day, dayPeriod, service, rCustomer);
            }
        }


        private JObject ExecuteQuery(string id_location, string id_day, string id_period_day, string service, string rCustomer)
        {
            AssignQueryValue(id_location, id_day, id_period_day, service, rCustomer);                      

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        InterfaceDataReader dataReader = new DataReader();
                        List<DayByTypeDTO> DTOList = new List<DayByTypeDTO>();
                        DTOList = dataReader.ReadDayByTypeDTO(reader);

                        IObjectConverter objConverted = new ObjectConverter();
                        var obj = objConverted.ByDayPeriodJson(DTOList);

                        return obj;                        
                    }
                }
            }
        }

        private void AssignQueryValue(string id_location, string id_day, string id_period_day, string service, string rCustomer)
        {
            if (service == "2")
            {
                _selectString = "SELECT b.id_day, b.name_day AS day, c.name_period, COUNT(DISTINCT a.src) AS people FROM collected_data a INNER JOIN days b ON a.id_day = b.id_day INNER JOIN out_day_periods c ON a.id_out_day_period = c.id_out_day_period WHERE a.id_location = " + id_location + " AND a.id_day = " + id_day + " AND a.id_out_day_period IN(" + id_period_day + ") AND a.id_service = " + service + " AND a.returning_customer IN(" + rCustomer + ") GROUP BY b.id_day, c.name_period, a.id_out_day_period ORDER BY a.id_out_day_period ASC";
            }
            else if (service == "1")
            {
                _selectString = "SELECT b.id_day, b.name_day AS day, c.name_period, COUNT(DISTINCT a.src) AS people FROM collected_data a INNER JOIN days b ON a.id_day = b.id_day INNER JOIN in_day_periods c ON a.id_in_day_period = c.id_in_day_period WHERE a.id_location = " + id_location + " AND a.id_day = " + id_day + " AND a.id_in_day_period IN(" + id_period_day + ") AND a.id_service = " + service + " AND a.returning_customer IN(" + rCustomer + ") GROUP BY b.id_day, c.name_period, a.id_in_day_period ORDER BY a.id_in_day_period ASC";
            }
        }
    }
}