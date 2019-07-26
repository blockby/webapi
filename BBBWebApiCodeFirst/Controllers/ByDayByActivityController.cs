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
    public class ByDayByActivityController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly string connectionString = ConnectionStringBuilder.buildConnectionString();

        private string _selectString;

        public ByDayByActivityController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("getbydaybyactivity")]
        public async Task<JObject> GetByDayByActivity()
        {
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                string result = await reader.ReadToEndAsync();

                var locationObj = JObject.Parse(result)["id_location"];
                var dayObj = JObject.Parse(result)["id_day"];
                var idActivityObj = JObject.Parse(result)["id_out_activity"];
                var serviceObj = JObject.Parse(result)["id_service"];
                var rCustomerObj = JObject.Parse(result)["returning_customer"];

                string location = locationObj.ToObject<string>();
                string day = dayObj.ToObject<string>();
                string idActivity = idActivityObj.ToObject<string>();
                string service = dayObj.ToObject<string>();
                string rCustomer = idActivityObj.ToObject<string>();

                return ExecuteQuery(location, day, idActivity, service, rCustomer);
            }
        }


        private JObject ExecuteQuery(string id_location, string id_day, string id_activity, string service, string returning_customer)
        {
            
            if (service == "1")
            {
                string _selectString = "SELECT b.id_day, b.name_day AS day, c.name_activity, COUNT(DISTINCT a.src) AS people FROM collected_data a INNER JOIN days b ON a.id_day = b.id_day INNER JOIN in_activitys c ON a.id_in_activity = c.id_in_activity WHERE a.id_location = " + id_location + " AND a.id_day = " + id_day + " AND a.id_in_activity IN(" + id_activity + ") AND a.id_service = " + service + " AND a.returning_customer = " + returning_customer + " GROUP BY b.id_day, c.id_in_activity ORDER BY a.id_in_activity ASC";
            }
            else if (service == "2")
            {
                string _selectString = "SELECT b.id_day, b.name_day AS day, c.name_activity, COUNT(DISTINCT a.src) AS people FROM collected_data a INNER JOIN days b ON a.id_day = b.id_day INNER JOIN out_activitys c ON a.id_out_activity = c.id_out_activity WHERE a.id_location = " + id_location + " AND a.id_day = " + id_day + " AND a.id_out_activity IN(" + id_activity + ") AND a.id_service = " + service + " AND a.returning_customer = " + returning_customer + " GROUP BY b.id_day, c.id_out_activity ORDER BY a.id_out_activity ASC";
            }

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<DayByTypeDTO> ByDayByActivityDTOList = new List<DayByTypeDTO>();

                        while (reader.Read())
                        {
                            InterfaceDataReader dataReader = new DataReader();
                            DayByTypeDTO byDayByActivityDTO = dataReader.ReadDayByTypeDTO(reader);
                            ByDayByActivityDTOList.Add(byDayByActivityDTO);
                        }

                        IObjectConverter objConverted = new ObjectConverter();
                        var obj = objConverted.ByDayByActivityJson(ByDayByActivityDTOList);

                        return obj;
                    }
                }
            }
        }
    }
}