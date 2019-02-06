using BBBWebApiCodeFirst.Common;
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
    public class HomeZoneWheelController: ControllerBase
    {
        private readonly DataContext _context;
        string connectionString = ConnectionStringBuilder.buildConnectionString();

        public HomeZoneWheelController(DataContext context)
        {
            _context = context;
        }

        //GET:api/HomeZone/gethomezonewheel/day/longy/lat
        [HttpGet("gethomezonewheel/{day}/{longy}/{lat}")]
        public JObject GetHomeZoneWheel([FromRoute] int day, double longy, double lat)
        {
            string _pointString = "POINT(" + longy + " " + lat + ")";
            string _selectString = "SELECT CAST(hz.\"SharedHz\" AS DOUBLE PRECISION) AS percent, ST_Distance(ST_Centroid(z1.\"Geom\")::geography, ST_Centroid(z2.\"Geom\")::geography) AS distance FROM \"MtcHomezones\" AS hz INNER JOIN \"Mtcs\" AS z1 ON z1.\"Gid\" = hz.\"ZoneHz\" INNER JOIN \"Mtc\" AS z2 ON z2.\"Gid\" = hz.\"HomeHz\" WHERE ST_Contains(z1.\"Geom\", ST_GeomFromText('" + _pointString + "', 4326))=true AND hz.\"DaysHz\" = " + day + " ORDER BY distance ASC";

            //using (var conn = new NpgsqlConnection(connectionString))
            //{
            //    conn.Open();

            //    using (var cmd = new NpgsqlCommand(_selectString, conn))
            //    {
            //        using (var reader = cmd.ExecuteReader())
            //        {
            //            List<MainChartDTO> mainChartDtoList = new List<MainChartDTO>();

            //            while (reader.Read())
            //            {
            //                InterfaceDataReader dataReader = new DataReader();
            //                MainChartDTO mainChartDTO = dataReader.ReadMainChartDTO(reader);
            //                mainChartDtoList.Add(mainChartDTO);
            //            }

            //            IObjectConverter objConverted = new ObjectConverter();
            //            var obj = objConverted.MainChartDayJson(mainChartDtoList);

            //            return obj;
            //        }
            //    }
            //}

            return new JObject();
        }
    }
}
