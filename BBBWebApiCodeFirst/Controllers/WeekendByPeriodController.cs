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

                string location = locationObj.ToObject<string>();
                string day = dayObj.ToObject<string>();
                string idPeriodDay = idPeriodDayObj.ToObject<string>();

                return ExecuteQuery(location, day, idPeriodDay);
            }
        }


        private JObject ExecuteQuery(string id_location, string id_day_type, string id_period_day)
        {
            string _selectString = "SELECT a.id_day AS id_day, b.name_day AS day, c.name_period, COUNT(DISTINCT  a.src) AS people FROM collected_data a INNER JOIN days b ON a.id_day = b.id_day INNER JOIN day_periods c ON a.id_period_day = c.id_day_period WHERE a.id_location = " + id_location+" AND b.id_day_type = "+id_day_type+" AND a.id_period_day IN("+id_period_day+") GROUP BY a.id_day,b.id_day,c.name_period,a.id_period_day ORDER BY a.id_day,a.id_period_day";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<TypeDayByPeriodDTO> WeekendByPeriodDTOList = new List<TypeDayByPeriodDTO>();

                        while (reader.Read())
                        {
                            InterfaceDataReader dataReader = new DataReader();
                            TypeDayByPeriodDTO weekendByPeriodDTO = dataReader.ReadTypeDayByPeriodDTO(reader);
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