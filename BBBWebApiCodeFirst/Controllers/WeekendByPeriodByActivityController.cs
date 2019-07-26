﻿using System;
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
    public class WeekendByPeriodByActivityController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly string connectionString = ConnectionStringBuilder.buildConnectionString();

        private string _selectString;

        public WeekendByPeriodByActivityController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("getweekendbyperiodbyactivity")]
        public async Task<JObject> GetWeekendByPeriodByActivity()
        {
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                string result = await reader.ReadToEndAsync();

                var locationObj = JObject.Parse(result)["id_location"];
                var idDayTypeObj = JObject.Parse(result)["id_day_type"];
                var idPeriodDayObj = JObject.Parse(result)["id_out_day_period"];
                var idActivityObj = JObject.Parse(result)["id_out_activity"];
                var serviceObj = JObject.Parse(result)["id_service"];
                var rCustomerObj = JObject.Parse(result)["returning_customer"];

                string location = locationObj.ToObject<string>();
                string idDayType = idDayTypeObj.ToObject<string>();
                string idPeriodDay = idPeriodDayObj.ToObject<string>();
                string idActivity = idActivityObj.ToObject<string>();
                string service = serviceObj.ToObject<string>();
                string rCustomer = rCustomerObj.ToObject<string>();

                return ExecuteQuery(location, idDayType, idPeriodDay, idActivity, service, rCustomer);
            }
        }


        private JObject ExecuteQuery(string id_location, string id_day_type, string id_period_day, string id_activity, string service, string returning_customer)
        {            

            if (service == "1")
            {
                _selectString = "SELECT b.id_day, b.name_day AS day, c.name_period, d.name_activity, COUNT(DISTINCT a.src) AS people FROM collected_data a INNER JOIN days b ON a.id_day = b.id_day INNER JOIN in_day_periods c ON a.id_in_day_period = c.id_in_day_period INNER JOIN in_activitys d ON a.id_in_activity = d.id_in_activity WHERE a.id_location = " + id_location + " AND b.id_day_type = " + id_day_type + " AND a.id_in_day_period IN(" + id_period_day + ") AND a.id_in_activity IN(" + id_activity + ") AND a.id_service = " + service + " AND a.returning_customer = " + returning_customer + " GROUP BY b.id_day, b.name_day, c.name_period, a.id_in_day_period, d.name_activity, a.id_in_activity ORDER BY b.id_day, a.id_in_day_period ASC";
            }
            else if (service == "2")
            {
                _selectString = "SELECT b.id_day, b.name_day AS day, c.name_period, d.name_activity, COUNT(DISTINCT a.src) AS people FROM collected_data a INNER JOIN days b ON a.id_day = b.id_day INNER JOIN out_day_periods c ON a.id_out_day_period = c.id_out_day_period INNER JOIN out_activitys d ON a.id_out_activity = d.id_out_activity WHERE a.id_location = " + id_location + " AND b.id_day_type = " + id_day_type + " AND a.id_out_day_period IN(" + id_period_day + ") AND a.id_out_activity IN(" + id_activity + ") AND a.id_service = " + service + " AND a.returning_customer = " + returning_customer + " GROUP BY b.id_day, b.name_day, c.name_period, a.id_out_day_period, d.name_activity, a.id_out_activity ORDER BY b.id_day, a.id_out_day_period ASC";
            }


            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<ByDayByPeriodByActivityDTO> WeekendByPeriodByActivityDTOList = new List<ByDayByPeriodByActivityDTO>();

                        while (reader.Read())
                        {
                            InterfaceDataReader dataReader = new DataReader();
                            ByDayByPeriodByActivityDTO WeekendByPeriodByActivityDTO = dataReader.ReadByDayByPeriodByActivityDTO(reader);
                            WeekendByPeriodByActivityDTOList.Add(WeekendByPeriodByActivityDTO);
                        }

                        IObjectConverter objConverted = new ObjectConverter();
                        var obj = objConverted.WeekendByPeriodByActivityJson(WeekendByPeriodByActivityDTOList);

                        return obj;
                    }
                }
            }
        }
    }
}