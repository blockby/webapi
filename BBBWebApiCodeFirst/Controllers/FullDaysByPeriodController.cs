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
    public class FullDaysByPeriodController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly string connectionString = ConnectionStringBuilder.buildConnectionString();

        public FullDaysByPeriodController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("getfulldaysbyperiod")]
        public async Task<JObject> GetFullDaysByPeriod()
        {
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                string result = await reader.ReadToEndAsync();

                var locationObj = JObject.Parse(result)["id_location"];
                var idDayPeriodObj = JObject.Parse(result)["id_out_day_period"];
                var serviceObj = JObject.Parse(result)["id_service"];
                var rCustomerObj = JObject.Parse(result)["returning_customer"];

                string location = locationObj.ToObject<string>();
                string idPeriodDay = idDayPeriodObj.ToObject<string>();
                string service = serviceObj.ToObject<string>();
                string rCustomer = rCustomerObj.ToObject<string>();

                return ExecuteQuery(location, idPeriodDay, service, rCustomer);
            }
        }


        private JObject ExecuteQuery(string id_location, string id_out_day_period, string id_service, string returning_customer)
        {
            string _selectString = "SELECT a.id_day, b.name_day AS day, c.name_period, COUNT(DISTINCT a.src) AS people FROM collected_data a INNER JOIN days b ON a.id_day = b.id_day INNER JOIN out_day_periods c ON a.id_out_day_period = c.id_out_day_period WHERE a.id_location = " + id_location+" AND a.id_out_day_period IN ("+ id_out_day_period + ") AND a.id_service = " + id_service + " AND a.returning_customer = "+ returning_customer +" GROUP BY a.id_day, b.id_day, c.name_period, a.id_out_day_period ORDER BY a.id_day,a.id_out_day_period";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<DayByTypeDTO> FullDaysByPeriodDTOList = new List<DayByTypeDTO>();

                        while (reader.Read())
                        {
                            InterfaceDataReader dataReader = new DataReader();
                            DayByTypeDTO fullDaysByPeriodDTO = dataReader.ReadDayByTypeDTO(reader);
                            FullDaysByPeriodDTOList.Add(fullDaysByPeriodDTO);
                        }

                        IObjectConverter objConverted = new ObjectConverter();
                        var obj = objConverted.FullDaysByPeriodJson(FullDaysByPeriodDTOList);

                        return obj;
                    }
                }
            }
        }
    }
}