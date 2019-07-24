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
    public class WeekDayByPeriodController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly string connectionString = ConnectionStringBuilder.buildConnectionString();

        public WeekDayByPeriodController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("getweekdaybyperiod")]
        public async Task<JObject> GetWeekDayByPeriod()
        {
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                string result = await reader.ReadToEndAsync();

                var locationObj = JObject.Parse(result)["id_location"];
                var dayObj = JObject.Parse(result)["id_day_type"];
                var idPeriodDayObj = JObject.Parse(result)["id_out_day_period"];
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


        private JObject ExecuteQuery(string id_location, string id_day_type, string id_period_day, string service, string returning_customer)
        {
            string _selectString = "SELECT a.id_day AS id_day, b.name_day AS day, c.name_period, COUNT(DISTINCT a.src) AS people FROM collected_data a INNER JOIN days b ON a.id_day = b.id_day INNER JOIN out_day_periods c ON a.id_out_day_period = c.id_out_day_period WHERE a.id_location = " + id_location+" AND b.id_day_type = "+id_day_type+" AND a.id_out_day_period IN("+id_period_day+") AND a.id_service = "+ service +" AND a.returning_customer = "+ returning_customer +" GROUP BY a.id_day, b.id_day,c.id_out_day_period ORDER BY a.id_out_day, c.id_out_day_period";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<DayByTypeDTO> WeekDayByPeriodDTOList = new List<DayByTypeDTO>();

                        while (reader.Read())
                        {
                            InterfaceDataReader dataReader = new DataReader();
                            DayByTypeDTO weekDayByPeriodDTO = dataReader.ReadDayByTypeDTO(reader);
                            WeekDayByPeriodDTOList.Add(weekDayByPeriodDTO);
                        }

                        IObjectConverter objConverted = new ObjectConverter();
                        var obj = objConverted.WeekDayByPeriodJson(WeekDayByPeriodDTOList);

                        return obj;
                    }
                }
            }
        }
    }
}