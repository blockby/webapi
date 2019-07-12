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
    public class FullDaysByPeriodByActivityController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly string connectionString = ConnectionStringBuilder.buildConnectionString();

        public FullDaysByPeriodByActivityController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("getfulldaysbyperiodbyactivity")]
        public async Task<JObject> GetFullDaysByPeriodByActivity()
        {
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                string result = await reader.ReadToEndAsync();

                var locationObj = JObject.Parse(result)["id_location"];
                var idPeriodDayObj = JObject.Parse(result)["id_period_day"];
                var idActivityObj = JObject.Parse(result)["id_activity"];

                string location = locationObj.ToObject<string>();
                string idPeriodDay = idPeriodDayObj.ToObject<string>();
                string idActivity = idActivityObj.ToObject<string>();

                return ExecuteQuery(location, idPeriodDay, idActivity);
            }
        }


        private JObject ExecuteQuery(string id_location, string id_period_day, string id_activity)
        {
            string _selectString = "SELECT a.id_day AS id_day, b.name_day AS day, c.name_period, d.name_activity, COUNT(DISTINCT a.src) AS people FROM collected_data a INNER JOIN days b ON a.id_day = b.id_day INNER JOIN day_periods c ON a.id_period_day = c.id_day_period INNER JOIN activitys d ON a.id_activity = d.id_activity WHERE a.id_location = "+id_location+" AND a.id_period_day IN("+id_period_day+") AND a.id_activity IN("+id_activity+ ") GROUP BY a.id_day, b.id_day, c.id_day_period, a.id_period_day, d.id_activity, a.id_activity ORDER BY a.id_day,a.id_period_day";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<ByDayByPeriodByActivityDTO> FullDaysByPeriodByActivityDTOList = new List<ByDayByPeriodByActivityDTO>();

                        while (reader.Read())
                        {
                            InterfaceDataReader dataReader = new DataReader();
                            ByDayByPeriodByActivityDTO fullDaysByPeriodByActivityDTO = dataReader.ReadByDayByPeriodByActivityDTO(reader);
                            FullDaysByPeriodByActivityDTOList.Add(fullDaysByPeriodByActivityDTO);
                        }

                        IObjectConverter objConverted = new ObjectConverter();
                        var obj = objConverted.FullDaysByPeriodByActivityJson(FullDaysByPeriodByActivityDTOList);

                        return obj;
                    }
                }
            }
        }
    }
}