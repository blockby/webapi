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

namespace BBBWebApiCodeFirst.Controllers
{
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

                var idUserObj = JObject.Parse(result)["id_user"];                
                string idUser = idUserObj.ToObject<string>();
                
                return ExecuteQuery(idUser);
            }
        }


        private JObject ExecuteQuery(string idUser)
        {
            string _selectString = "SELECT a.id_location, d.id_user, d.name AS owner,a.address, c.type_prop, ST_X(a.coordinates) AS longitude, ST_Y(a.coordinates) AS latitude, b.state FROM locations a INNER JOIN shared_locations b ON a.id_location = b.id_location INNER JOIN property_types c ON a.id_prop_type = c.id_type_prop INNER JOIN users d ON b.id_user = d.id_user WHERE b.id_user = "+idUser+" AND b.state = True";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<SharedLocationDTO> sharedLocationDTOList = new List<SharedLocationDTO>();

                        while (reader.Read())
                        {
                            InterfaceDataReader dataReader = new DataReader();
                            SharedLocationDTO sharedLocationDTO = dataReader.ReadSharedLocationDTO(reader);
                            sharedLocationDTOList.Add(sharedLocationDTO);
                        }

                        IObjectConverter objConverted = new ObjectConverter();
                        var obj = objConverted.sharedLocationJson(sharedLocationDTOList);

                        return obj;

                    }
                }
            }
        }
    }
}