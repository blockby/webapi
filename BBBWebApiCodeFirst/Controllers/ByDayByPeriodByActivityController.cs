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
    public class ByDayByPeriodByActivityController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly string connectionString = ConnectionStringBuilder.buildConnectionString();

        public ByDayByPeriodByActivityController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("getbydaybyperiodbyactivity")]
        public async Task<JObject> GetByDayByPeriodByActivity()
        {
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                string result = await reader.ReadToEndAsync();

                var locationObj = JObject.Parse(result)["id_location"];
                var idDayObj = JObject.Parse(result)["id_day"];
                var idPeriodDayObj = JObject.Parse(result)["id_period_day"];
                var idActivityObj = JObject.Parse(result)["id_activity"];

                string location = locationObj.ToObject<string>();
                string idDay = idDayObj.ToObject<string>();
                string idPeriodDay = idPeriodDayObj.ToObject<string>();
                string idActivity = idActivityObj.ToObject<string>();

                return ExecuteQuery(location, idDay, idPeriodDay, idActivity);
            }
        }


        private JObject ExecuteQuery(string id_location, string id_day, string id_period_day, string id_activity)
        {
            string _selectString = "SELECT b.id_day,b.name_day AS day, c.name_period, d.name_activity, COUNT(DISTINCT a.src) AS people FROM collected_data a INNER JOIN days b ON a.id_day = b.id_day INNER JOIN day_periods c ON a.id_period_day = c.id_day_period INNER JOIN activitys d ON a.id_activity = d.id_activity WHERE a.id_location = "+id_location+" AND a.id_day = "+id_day+" AND a.id_period_day IN("+id_period_day+") AND a.id_activity IN("+id_activity+") GROUP BY b.id_day,b.name_day, c.name_period, a.id_period_day, d.name_activity, a.id_activity ORDER BY a.id_period_day ASC";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<ByDayByPeriodByActivityDTO> ByDayByPeriodByActivityDTOList = new List<ByDayByPeriodByActivityDTO>();

                        while (reader.Read())
                        {
                            InterfaceDataReader dataReader = new DataReader();
                            ByDayByPeriodByActivityDTO ByDayByPeriodByActivityDTO = dataReader.ReadByDayByPeriodByActivityDTO(reader);
                            ByDayByPeriodByActivityDTOList.Add(ByDayByPeriodByActivityDTO);
                        }

                        IObjectConverter objConverted = new ObjectConverter();
                        var obj = objConverted.ByDayByPeriodByActivityJson(ByDayByPeriodByActivityDTOList, id_day);

                        return obj;
                    }
                }
            }
        }
    }
}