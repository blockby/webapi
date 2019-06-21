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
    public class WeekDaysByActivityController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly string connectionString = ConnectionStringBuilder.buildConnectionString();

        public WeekDaysByActivityController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("getweekdaysbyactivity")]
        public async Task<JObject> GetWeekDaysByActivity()
        {
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                string result = await reader.ReadToEndAsync();

                var locationObj = JObject.Parse(result)["id_location"];
                var idDayTypeObj = JObject.Parse(result)["id_day_type"];
                var idActivityObj = JObject.Parse(result)["id_activity"];

                string location = locationObj.ToObject<string>();
                string idDayType = idDayTypeObj.ToObject<string>();
                string idActivity = idActivityObj.ToObject<string>();

                return ExecuteQuery(location, idDayType, idActivity);
            }
        }


        private JObject ExecuteQuery(string id_location, string id_day_type, string id_activity)
        {
            string _selectString = "SELECT a.id_day AS id_day, b.name_day AS day, c.type_day, d.name_activity, COUNT(DISTINCT  a.src) AS people FROM collected_data a INNER JOIN days b ON a.id_day = b.id_day INNER JOIN day_types c ON b.id_day_type = c.id_type_day INNER JOIN activitys d ON a.id_activity = d.id_activity WHERE a.id_location = " + id_location+" AND b.id_day_type = "+id_day_type+" AND a.id_activity IN("+id_activity+") GROUP BY a.id_day,b.name_day, c.type_day, d.name_activity, a.id_activity ORDER BY a.id_day, a.id_activity";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<WeekDaysByActivityDTO> WeekDaysByActivityDTOList = new List<WeekDaysByActivityDTO>();

                        while (reader.Read())
                        {
                            InterfaceDataReader dataReader = new DataReader();
                            WeekDaysByActivityDTO weekDaysByActivityDTO = dataReader.ReadWeekDaysByActivityDTO(reader);
                            WeekDaysByActivityDTOList.Add(weekDaysByActivityDTO);
                        }

                        IObjectConverter objConverted = new ObjectConverter();
                        var obj = objConverted.WeekDaysByActivityJson(WeekDaysByActivityDTOList);

                        return obj;
                    }
                }
            }
        }
    }
}