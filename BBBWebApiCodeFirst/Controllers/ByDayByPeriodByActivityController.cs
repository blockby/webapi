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

        private string _selectString;
        private string _preSelectString;
        private string filterSpecification;

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
                
                string location = JObject.Parse(result)["id_location"].ToObject<string>();
                string idDay = JObject.Parse(result)["id_day"].ToObject<string>();
                string idPeriodDay = JObject.Parse(result)["id_day_period"].ToObject<string>();
                string idActivity = JObject.Parse(result)["id_activity"].ToObject<string>();
                string service = JObject.Parse(result)["id_activity"].ToObject<string>();
                string rCustomer = JObject.Parse(result)["returning_customer"].ToObject<string>();
                
                return ExecuteQuery(location, idDay, idPeriodDay, idActivity, service, rCustomer);
            }
        }


        private JObject ExecuteQuery(string id_location, string id_day, string id_period_day, string id_activity, string service, string returning_customer)
        {
            AssignQueryValue(id_location, id_day, id_period_day, id_activity, service, returning_customer);

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        InterfaceDataReader dataReader = new DataReader();
                        List<ByDayByPeriodByActivityDTO> DTOList = new List<ByDayByPeriodByActivityDTO>();
                        DTOList = dataReader.ReadByDayByPeriodByActivityDTO(reader);

                        IObjectConverter objConverted = new ObjectConverter();
                        var obj = objConverted.ByDayByPeriodByActivityJson(DTOList, service, service, filterSpecification);

                        return obj;                        
                    }
                }
            }
        }

        private void AssignQueryValue(string id_location, string id_day, string id_period_day, string id_activity, string service, string returning_customer)
        {
            if (service == "1")
            {
                if (id_activity == "1")
                {
                    _selectString = buildInsideCustomerString(id_location, id_day, id_period_day, "3,4", "8", service, returning_customer);
                    filterSpecification = "customer_spec";
                }
                else if (id_activity == "1,2" || id_activity == "2,1")
                {
                    _selectString = buildInsideCustomerString(id_location, id_day, id_period_day, "3,4", "2", service, returning_customer);
                    filterSpecification = "customer_spec";
                }
                else if (id_activity == "2")
                {
                    _selectString = buildInsideCustomerString(id_location, id_day, id_period_day, "2", "8", service, returning_customer);
                    filterSpecification = "customer_spec";
                }
                else if (id_activity == "3" || id_activity == "4" || id_activity == "3,4" || id_activity == "4,3")
                {
                    _selectString = "SELECT b.id_day,b.name_day AS day, c.name_period, d.name_activity, COUNT(DISTINCT a.src) AS people FROM collected_data a INNER JOIN days b ON a.id_day = b.id_day INNER JOIN in_day_periods c ON a.id_in_day_period = c.id_in_day_period INNER JOIN in_activitys d ON a.id_in_activity = d.id_in_activity WHERE a.id_location = " + id_location + " AND a.id_day = " + id_day + " AND a.id_in_day_period IN(" + id_period_day + ") AND a.id_in_activity IN(" + id_activity + ") AND a.id_service = " + service + " AND a.returning_customer IN(" + returning_customer + ") GROUP BY b.id_day, c.id_in_day_period, d.id_in_activity ORDER BY c.id_in_day_period ASC";
                    filterSpecification = "transaction_spec";
                }
            }
            else if (service == "2")
            {
                _selectString = "SELECT b.id_day,b.name_day AS day, c.name_period, d.name_activity, COUNT(DISTINCT a.src) AS people FROM collected_data a INNER JOIN days b ON a.id_day = b.id_day INNER JOIN out_day_periods c ON a.id_out_day_period = c.id_out_day_period INNER JOIN out_activitys d ON a.id_out_activity = d.id_out_activity WHERE a.id_location = " + id_location + " AND a.id_day = " + id_day + " AND a.id_out_day_period IN(" + id_period_day + ") AND a.id_out_activity IN(" + id_activity + ") AND a.id_service = " + service + " AND a.returning_customer IN(" + returning_customer + ") GROUP BY b.id_day, c.id_out_day_period, d.id_out_activity ORDER BY c.id_out_day_period ASC";
            }
        }

        private string buildInsideCustomerString(string id_location, string id_day, string id_period_day, string id_activity1, string id_activity2, string service, string returning_customer)
        {
            _preSelectString = "SELECT id_day, day, name_period, name_activity, SUM(people) AS people FROM ((SELECT b.id_day,b.name_day AS day, c.id_in_day_period,c.name_period, 'Take_away Customers' AS name_activity,COUNT(DISTINCT a.src) AS people FROM collected_data a INNER JOIN days b ON a.id_day = b.id_day INNER JOIN in_day_periods c ON a.id_in_day_period = c.id_in_day_period INNER JOIN in_activitys d ON a.id_in_activity = d.id_in_activity WHERE a.id_location = " + id_location + " AND a.id_day = " + id_day + " AND a.id_in_day_period IN(" + id_period_day + ") AND a.id_in_activity IN(" + id_activity1 + ") AND a.id_service = " + service + " AND a.returning_customer IN(" + returning_customer + ") GROUP BY b.id_day, c.id_in_day_period, d.id_in_activity ORDER BY c.id_in_day_period ASC) UNION(SELECT b.id_day, b.name_day AS day, c.id_in_day_period, c.name_period, d.name_activity, COUNT(DISTINCT a.src) AS people FROM collected_data a INNER JOIN days b ON a.id_day = b.id_day INNER JOIN in_day_periods c ON a.id_in_day_period = c.id_in_day_period INNER JOIN in_activitys d ON a.id_in_activity = d.id_in_activity WHERE a.id_location = " + id_location + " AND a.id_day = " + id_day + " AND a.id_in_day_period IN(" + id_period_day + ") AND a.id_in_activity IN(" + id_activity2 + ") AND a.id_service = " + service + " AND a.returning_customer IN(" + returning_customer + ") GROUP BY b.id_day, c.id_in_day_period, d.id_in_activity ORDER BY c.id_in_day_period ASC)) AS tb1 GROUP BY id_day,day, id_in_day_period, name_period, name_activity ORDER BY id_in_day_period ASC";
            return _preSelectString;
        }
    }
}