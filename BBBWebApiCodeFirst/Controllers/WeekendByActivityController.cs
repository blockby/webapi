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
    public class WeekendByActivityController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly string connectionString = ConnectionStringBuilder.buildConnectionString();

        private string _selectString;

        public WeekendByActivityController(DataContext context)
        {
            _context = context;
        }

        
        [HttpPost("getweekendbyactivity")]
        public async Task<JObject> GetWeekEndByActivity()
        {
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                string result = await reader.ReadToEndAsync();

                var locationObj = JObject.Parse(result)["id_location"];
                var idDayTypeObj = JObject.Parse(result)["id_day_type"];
                var idActivityObj = JObject.Parse(result)["id_out_activity"];
                var serviceObj = JObject.Parse(result)["id_service"];
                var rCustomerObj = JObject.Parse(result)["returning_customer"];
                

                string location = locationObj.ToObject<string>();
                string idDayType = idDayTypeObj.ToObject<string>();
                string idActivity = idActivityObj.ToObject<string>();
                string service = serviceObj.ToObject<string>();
                string rCustomer = rCustomerObj.ToObject<string>();

                return ExecuteQuery(location, idDayType, idActivity, service, rCustomer);
            }
        }


        private JObject ExecuteQuery(string id_location, string id_day_type, string id_activity, string service, string rCustomer)
        {           

            if (service == "1")
            {
                _selectString = "SELECT a.id_day AS id_day, b.name_day AS day, a.id_day_type, d.name_activity, COUNT(DISTINCT a.src) AS people FROM collected_data a INNER JOIN days b ON a.id_day = b.id_day INNER JOIN in_activitys d ON a.id_in_activity = d.id_in_activity WHERE a.id_location = " + id_location + " AND b.id_day_type = " + id_day_type + " AND a.id_in_activity IN(" + id_activity + ") AND a.id_service = " + service + " AND a.returning_customer = " + rCustomer + " GROUP BY b.id_day, a.id_day_type, d.id_in_activity ORDER BY a.id_day, a.id_in_activity";
            }
            else if (service == "2")
            {
                _selectString = "SELECT a.id_day AS id_day, b.name_day AS day, a.id_day_type, d.name_activity, COUNT(DISTINCT a.src) AS people FROM collected_data a INNER JOIN days b ON a.id_day = b.id_day INNER JOIN out_activitys d ON a.id_out_activity = d.id_out_activity WHERE a.id_location = " + id_location + " AND b.id_day_type = " + id_day_type + " AND a.id_out_activity IN(" + id_activity + ") AND a.id_service = " + service + " AND a.returning_customer = " + rCustomer + " GROUP BY b.id_day, a.id_day_type, d.id_out_activity ORDER BY a.id_day, a.id_out_activity";
            }

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<DaysByActivityDTO> WeekendByActivityDTOList = new List<DaysByActivityDTO>();

                        while (reader.Read())
                        {
                            InterfaceDataReader dataReader = new DataReader();
                            DaysByActivityDTO weekendByActivityDTO = dataReader.ReadDaysByActivityDTO(reader);
                            WeekendByActivityDTOList.Add(weekendByActivityDTO);
                        }

                        IObjectConverter objConverted = new ObjectConverter();
                        var obj = objConverted.WeekendByActivityJson(WeekendByActivityDTOList);

                        return obj;
                    }
                }
            }
        }
    }
}