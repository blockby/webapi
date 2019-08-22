using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBBWebApiCodeFirst.Common;
using BBBWebApiCodeFirst.Models;
using BBBWebApiCodeFirst.Converters;
using BBBWebApiCodeFirst.DataReaders;
using BBBWebApiCodeFirst.DataTransferObjects;
using BBBWebApiCodeFirst.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Npgsql;
using Microsoft.AspNetCore.Authorization;

namespace BBBWebApiCodeFirst.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SharedLocationsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly string connectionString = ConnectionStringBuilder.buildConnectionString();

        public SharedLocationsController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("getsharedlocation")]
        public async Task<JObject> SharedLocation()
        {
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                string result = await reader.ReadToEndAsync();
                string idUser = JObject.Parse(result)["id_user"].ToObject<string>();
                string state = JObject.Parse(result)["state"].ToObject<string>();                
                return ExecuteQuery(idUser, state);
            }
        }        

        private JObject ExecuteQuery(string idUser, string state)
        {
            string _selectString = "SELECT a.id_location, d.\"Id\", d.\"UserName\" AS owner, a.address, c.prop_type, ST_X(a.coordinates) AS longitude, ST_Y(a.coordinates) AS latitude, b.state, a.id_service FROM locations a INNER JOIN shared_locations b ON a.id_location = b.id_location INNER JOIN property_types c ON a.id_prop_type = c.id_prop_type INNER JOIN \"AspNetUsers\" d ON b.id_user = d.\"Id\" WHERE b.id_user = "+idUser+" AND b.state = "+state+"";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        SharedLocationDTO sharedLocationDTO = new SharedLocationDTO();

                        while (reader.Read())
                        {
                            InterfaceDataReader dataReader = new DataReader();                            
                            sharedLocationDTO = dataReader.ReadSharedLocationDTO(reader);                            
                        }
                        IObjectConverter objConverted = new ObjectConverter();
                        var obj = objConverted.sharedLocationJson(sharedLocationDTO);

                        return obj;

                    }
                }
            }
        }
    }
}