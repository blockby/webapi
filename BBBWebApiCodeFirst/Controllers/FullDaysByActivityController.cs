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
using BBBWebApiCodeFirst.Converters;
using Npgsql;

namespace BBBWebApiCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FullDaysByActivityController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly string connectionString = ConnectionStringBuilder.buildConnectionString();

        public FullDaysByActivityController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("getfulldaysbyactivity")]
        public async Task<JObject> GetFullDaysByActivity()
        {
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                string result = await reader.ReadToEndAsync();

                var locationObj = JObject.Parse(result)["id_location"];
                var idActivityObj = JObject.Parse(result)["id_out_activity"];
                var serviceObj = JObject.Parse(result)["id_service"];
                var rCustomerObj = JObject.Parse(result)["returning_customer"];


                string location = locationObj.ToObject<string>();                
                string idActivity = idActivityObj.ToObject<string>();
                string service = serviceObj.ToObject<string>();
                string rCustomer = rCustomerObj.ToObject<string>();

                return ExecuteQuery(location, idActivity, service, rCustomer);
            }
        }


        private JObject ExecuteQuery(string id_location, string id_activity, string id_service, string returning_customer)
        {
            string _selectString = "SELECT a.id_day AS id_day, b.name_day AS day, c.name_activity, COUNT(DISTINCT a.src) AS people FROM collected_data a INNER JOIN days b ON a.id_day = b.id_day INNER JOIN out_activitys c ON a.id_out_activity = c.id_out_activity WHERE a.id_location = " + id_location + " AND a.id_out_activity IN(" + id_activity + " AND a.returning_customer = "+ returning_customer + ") GROUP BY a.id_day, b.id_day, c.id_out_activity ORDER BY a.id_day, c.id_out_activity";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<DayByTypeDTO> FullDaysByActivityDTOList = new List<DayByTypeDTO>();

                        while (reader.Read())
                        {
                            InterfaceDataReader dataReader = new DataReader();
                            DayByTypeDTO fullDaysByActivityDTO = dataReader.ReadDayByTypeDTO(reader);
                            FullDaysByActivityDTOList.Add(fullDaysByActivityDTO);
                        }

                        IObjectConverter objConverted = new ObjectConverter();
                        var obj = objConverted.FullDaysByActivityJson(FullDaysByActivityDTOList);

                        return obj;
                    }
                }
            }
        }
    }
}