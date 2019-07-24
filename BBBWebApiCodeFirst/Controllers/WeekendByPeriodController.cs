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
    public class WeekendByPeriodController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly string connectionString = ConnectionStringBuilder.buildConnectionString();

        public WeekendByPeriodController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("getweekendbyperiod")]
        public async Task<JObject> GetWeekendByPeriod()
        {
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                string result = await reader.ReadToEndAsync();

                var locationObj = JObject.Parse(result)["id_location"];
                var dayObj = JObject.Parse(result)["id_day_type"];
                var idPeriodDayObj = JObject.Parse(result)["id_period_day"];
                var serviceObj = JObject.Parse(result)["id_service"];
                var rCustomerObj = JObject.Parse(result)["returning_customer"];

                string location = locationObj.ToObject<string>();
                string day = dayObj.ToObject<string>();
                string idPeriodDay = idPeriodDayObj.ToObject<string>();
                string service = serviceObj.ToObject<string>();
                string rCustomer = rCustomerObj.ToObject<string>();

                return ExecuteQuery(location, day, idPeriodDay, service, rCustomer);
            }
        }


        private JObject ExecuteQuery(string id_location, string id_day_type, string id_period_day, string id_service, string returning_customer)
        {
            string _selectString = "SELECT a.id_day AS id_day, b.name_day AS day, c.name_period, COUNT(DISTINCT a.src) AS people FROM collected_data a INNER JOIN days b ON a.id_day = b.id_day INNER JOIN out_day_periods c ON a.id_out_day_period = c.id_out_day_period WHERE a.id_location = " + id_location+" AND a.id_day_type = "+ id_day_type + " AND a.id_out_day_period IN(" + id_period_day+") AND a.id_service = "+ id_service +" AND a.returning_customer = "+ returning_customer +" GROUP BY a.id_day, b.id_day, c.id_out_day_period, ORDER BY a.id_day, a.id_out_day_period";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<DayByTypeDTO> WeekendByPeriodDTOList = new List<DayByTypeDTO>();

                        while (reader.Read())
                        {
                            InterfaceDataReader dataReader = new DataReader();
                            DayByTypeDTO weekendByPeriodDTO = dataReader.ReadDayByTypeDTO(reader);
                            WeekendByPeriodDTOList.Add(weekendByPeriodDTO);
                        }

                        IObjectConverter objConverted = new ObjectConverter();
                        var obj = objConverted.WeekendByPeriodJson(WeekendByPeriodDTOList);

                        return obj;
                    }
                }
            }
        }

    }
}