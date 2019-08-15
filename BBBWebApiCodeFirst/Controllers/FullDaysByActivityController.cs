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

        private string _selectString;
        private string _preSelectString;        
        private string filterSpecification;

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
                                
                string location = JObject.Parse(result)["id_location"].ToObject<string>();                
                string idActivity = JObject.Parse(result)["id_activity"].ToObject<string>();
                string service = JObject.Parse(result)["id_service"].ToObject<string>();
                string rCustomer = JObject.Parse(result)["returning_customer"].ToObject<string>();

                return ExecuteQuery(location, idActivity, service, rCustomer);
            }
        }


        private JObject ExecuteQuery(string id_location, string id_activity, string service, string returning_customer)
        {
            AssignQueryStringValue(id_location, id_activity, service, returning_customer);

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        InterfaceDataReader dataReader = new DataReader();
                        List<DayByTypeDTO> DTOList = new List<DayByTypeDTO>();
                        DTOList = dataReader.ReadDayByTypeDTO(reader);

                        IObjectConverter objConverted = new ObjectConverter();
                        var obj = objConverted.FullDaysByActivityJson(DTOList, service, filterSpecification);

                        return obj;                        
                    }
                }
            }
        }


        private void AssignQueryStringValue(string id_location, string id_activity, string service, string returning_customer)
        {
            if (service == "1")
            {
                if (id_activity == "1")
                {
                    _selectString = buildInsideCustomerString(id_location, "3,4", "8", service, returning_customer);
                    filterSpecification = "customer_spec";
                }
                else if (id_activity == "1,2" || id_activity == "2,1")
                {
                    _selectString = buildInsideCustomerString(id_location, "3,4", "2", service, returning_customer);
                    filterSpecification = "customer_spec";
                }
                else if (id_activity == "2")
                {
                    _selectString = buildInsideCustomerString(id_location, "8", "2", service, returning_customer);
                    filterSpecification = "customer_spec";
                }
                else if (id_activity == "3" || id_activity == "4" || id_activity == "3,4" || id_activity == "4,3")
                {
                    _selectString = "SELECT a.id_day AS id_day, b.name_day AS day, c.name_activity, COUNT(DISTINCT a.src) AS people FROM collected_data a INNER JOIN days b ON a.id_day = b.id_day INNER JOIN in_activitys c ON a.id_in_activity = c.id_in_activity WHERE a.id_location = " + id_location + " AND a.id_in_activity IN(" + id_activity + ") AND a.returning_customer IN(" + returning_customer + ") GROUP BY a.id_day, b.id_day, c.id_in_activity ORDER BY a.id_day, c.id_in_activity";
                    filterSpecification = "transaction_spec";
                }
            }
            else if (service == "2")
            {
                _selectString = "SELECT a.id_day AS id_day, b.name_day AS day, c.name_activity, COUNT(DISTINCT a.src) AS people FROM collected_data a INNER JOIN days b ON a.id_day = b.id_day INNER JOIN out_activitys c ON a.id_out_activity = c.id_out_activity WHERE a.id_location = " + id_location + " AND a.id_out_activity IN(" + id_activity + ") AND a.returning_customer IN(" + returning_customer + ") GROUP BY a.id_day, b.id_day, c.id_out_activity ORDER BY a.id_day, c.id_out_activity";
            }
        }


        private string buildInsideCustomerString(string id_location, string id_activity1, string id_activity2, string service, string returning_customer)
        {
            _preSelectString = "SELECT id_day, day, name_activity, SUM(people) as people FROM((SELECT a.id_day AS id_day, b.name_day AS day, 'Take_away Customers' AS name_activity, COUNT(DISTINCT a.src) AS people FROM collected_data a INNER JOIN days b ON a.id_day = b.id_day INNER JOIN in_activitys c ON a.id_in_activity = c.id_in_activity WHERE a.id_location = "+id_location+" AND a.id_in_activity IN("+id_activity1+") AND a.id_service = "+service+" AND a.returning_customer IN("+returning_customer+") GROUP BY a.id_day, b.name_day, a.id_in_activity ORDER BY a.id_day) UNION(SELECT a.id_day AS id_day, b.name_day AS day, c.name_activity, COUNT(DISTINCT a.src) AS people FROM collected_data a INNER JOIN days b ON a.id_day = b.id_day INNER JOIN in_activitys c ON a.id_in_activity = c.id_in_activity WHERE a.id_location = "+id_location+" AND a.id_in_activity IN("+id_activity2+") AND a.id_service = "+service+" AND a.returning_customer IN("+returning_customer+") GROUP BY a.id_day, b.id_day, c.name_activity ORDER BY a.id_day) ) AS tb1 GROUP BY id_day,day, name_activity";
            return _preSelectString;
        }
    }
}