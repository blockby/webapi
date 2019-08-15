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
    public class TypeDaysByPeriodController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly string connectionString = ConnectionStringBuilder.buildConnectionString();

        private string _selectString;

        public TypeDaysByPeriodController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("gettypedaysbyperiod")]
        public async Task<JObject> GetWeekDayByPeriod()
        {
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                string result = await reader.ReadToEndAsync();

                string location = JObject.Parse(result)["id_location"].ToObject<string>();
                string day = JObject.Parse(result)["id_day_type"].ToObject<string>();
                string idPeriodDay = JObject.Parse(result)["id_day_period"].ToObject<string>();
                string service = JObject.Parse(result)["id_service"].ToObject<string>();
                string rCustomer = JObject.Parse(result)["returning_customer"].ToObject<string>();

                return ExecuteQuery(location, day, idPeriodDay, service, rCustomer);
            }
        }


        private JObject ExecuteQuery(string id_location, string id_day_type, string id_period_day, string service, string returning_customer)
        {

            if (service == "1")
            {
                _selectString = "SELECT a.id_day AS id_day, b.name_day AS day, c.name_period, COUNT(DISTINCT a.src) AS people FROM collected_data a INNER JOIN days b ON a.id_day = b.id_day INNER JOIN in_day_periods c ON a.id_in_day_period = c.id_in_day_period WHERE a.id_location = " + id_location + " AND a.id_day_type = " + id_day_type + " AND a.id_in_day_period IN(" + id_period_day + ") AND a.id_service = " + service + " AND a.returning_customer IN(" + returning_customer + ") GROUP BY a.id_day, b.id_day,c.id_in_day_period ORDER BY a.id_day, c.id_in_day_period";
                
            }
            else if (service == "2")
            {
                _selectString = "SELECT a.id_day AS id_day, b.name_day AS day, c.name_period, COUNT(DISTINCT a.src) AS people FROM collected_data a INNER JOIN days b ON a.id_day = b.id_day INNER JOIN out_day_periods c ON a.id_out_day_period = c.id_out_day_period WHERE a.id_location = " + id_location + " AND a.id_day_type = " + id_day_type + " AND a.id_out_day_period IN(" + id_period_day + ") AND a.id_service = " + service + " AND a.returning_customer IN(" + returning_customer + ") GROUP BY a.id_day, b.id_day,c.id_out_day_period ORDER BY a.id_day, c.id_out_day_period";
            }

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
                        var obj = objConverted.TypeDayByPeriodJson(DTOList, service, id_day_type);

                        return obj;                        
                    }
                }
            }
        }
    }
}