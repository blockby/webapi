using BBBWebApiCodeFirst.Common;
using BBBWebApiCodeFirst.Converters;
using BBBWebApiCodeFirst.DataReaders;
using BBBWebApiCodeFirst.DataTransferObjects;
using BBBWebApiCodeFirst.Interfaces;
using BBBWebApiCodeFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AreaInfluenceController: ControllerBase
    {

        private readonly DataContext _context;
        string connectionString = ConnectionStringBuilder.buildConnectionString();

        //GET:api/AreaInfluence/getareainfluenceday/day/longy/lat
        [HttpGet("getareainfluenceday/{day}/{longy}/{lat}")]
        public JObject GetAreaInfluenceDay([FromRoute] int day, double longy, double lat)
        {            
            string _selectString = "SELECT SUM(ST_Area(homezone.geom::geography)) / 1000000 AS area FROM \"MtcHomezones\" AS hz INNER JOIN \"Mtcs\" AS homezone ON homezone.id = hz.homezone INNER JOIN \"Mtcs\" AS zone ON zone.id = hz.zone WHERE ST_Contains(zone.geom, ST_SetSRID(ST_MakePoint("+longy+", "+lat+"), 4326)) AND hz.day = "+day+"";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<AreaOfInfluenceDTO> AreaOfInfluenceDtoList = new List<AreaOfInfluenceDTO>();

                        while (reader.Read())
                        {
                            InterfaceDataReader dataReader = new DataReader();
                            AreaOfInfluenceDTO areaOfInfluenceDTO = dataReader.ReadAreaOfInfluenceDTO(reader);
                            AreaOfInfluenceDtoList.Add(areaOfInfluenceDTO);
                        }

                        IObjectConverter objConverted = new ObjectConverter();
                        var obj = objConverted.AreaOfInfluenceJson(AreaOfInfluenceDtoList);

                        return obj;
                    }
                }
            }

            return new JObject();
        }

        //GET:api/AreaInfluence/getareainfluenceweek/longy/lat
        [HttpGet("getareainfluenceweek/{longy}/{lat}")]
        public JObject GetAreaInfluenceWeek([FromRoute] double longy, double lat)
        {
            
            string _selectString = "SELECT SUM(AREA) / 1000000 AS area FROM(SELECT DISTINCT ON(homezone) ST_Area(homezone.geom::geography) as AREA FROM \"MtcHomezones\" AS hz INNER JOIN \"Mtcs\" AS homezone ON homezone.id = hz.homezone INNER JOIN \"Mtcs\" AS zone ON zone.id = hz.zone WHERE ST_Contains(zone.geom, ST_SetSRID(ST_MakePoint(" + longy + " , " + lat + "), 4326))) s";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<AreaOfInfluenceDTO> areaOfInfluenceDtoList = new List<AreaOfInfluenceDTO>();

                        while (reader.Read())
                        {
                            InterfaceDataReader dataReader = new DataReader();
                            AreaOfInfluenceDTO areaOfInfluenceDTO = dataReader.ReadAreaOfInfluenceDTO(reader);
                            areaOfInfluenceDtoList.Add(areaOfInfluenceDTO);
                        }

                        IObjectConverter objConverted = new ObjectConverter();
                        var obj = objConverted.AreaOfInfluenceJson(areaOfInfluenceDtoList);

                        return obj;
                    }
                }
            }


            return new JObject();
        }
    }
}
