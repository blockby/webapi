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
    public class TableHomeController: ControllerBase
    {
        private readonly DataContext _context;

        private readonly string connectionString = "User ID = mario; Password = abcd; Server = localhost; Port = 5432; Database = BlockDb; Integrated Security = true; Pooling = true;";
        //private readonly string connectionString = "User ID = postgres; Password = Cl4nd3st1n0; Server = localhost; Port = 5432; Database = BlockDb; Integrated Security = true; Pooling = true;";
        //private readonly string connectionString = "User ID = postgres; Password = postgres; Server = localhost; Port = 5432; Database = BlockDb; Integrated Security = true; Pooling = true;";

        public TableHomeController (DataContext context)
        {
            _context = context;
        }

        //GET:api/TableHome/gettablehomeday/day/longy/lat
        [HttpGet("gettablehomeday/{day}/{longy}/{lat}")]
        public JObject GetTableHomeDay([FromRoute] int day, double longy, double lat)
        {
            string _pointString = "POINT(" + longy + " " + lat + ")";
            string _selectString = "SELECT b.\"Gid\", b.\"Id\", a.\"ZoneAct\", a.\"DaysAct\", c.\"NameDay\", a.\"HoursAct\", a.\"CountAct\", b.\"Geom\" FROM \"MtcActivitys\" a INNER JOIN \"Mtcs\" b ON a.\"ZoneAct\" = b.\"Gid\" INNER JOIN \"Dayss\" c ON a.\"DaysAct\" = c.\"IdDay\" WHERE \"CountAct\" = (SELECT MAX(\"CountAct\") FROM \"MtcActivitys\" AS f WHERE f.\"ZoneAct\" = a.\"ZoneAct\" AND f.\"DaysAct\" = a.\"DaysAct\") AND ST_Contains(b.\"Geom\", ST_GeomFromText('" + _pointString + "', 4326))= true AND a.\"DaysAct\" = " + day + " UNION SELECT b.\"Gid\", b.\"Id\", a.\"ZoneAct\", a.\"DaysAct\", c.\"NameDay\", a.\"HoursAct\", a.\"CountAct\", b.\"Geom\" FROM \"MtcActivitys\" a INNER JOIN \"Mtcs\" b ON a.\"ZoneAct\" = b.\"Gid\" INNER JOIN \"Dayss\" c ON a.\"DaysAct\" = c.\"IdDay\" WHERE \"CountAct\" = (SELECT MIN(\"CountAct\") FROM \"MtcActivitys\" AS f WHERE f.\"ZoneAct\" = a.\"ZoneAct\" AND f.\"DaysAct\" = a.\"DaysAct\") AND ST_Contains(b.\"Geom\", ST_GeomFromText('" + _pointString + "', 4326))= true AND a.\"DaysAct\" = " + day + " ORDER BY \"CountAct\" DESC";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<TableHomeDayDTO> tableHomeDayDtoList = new List<TableHomeDayDTO>();

                        while (reader.Read())
                        {
                            InterfaceDataReader dataReader = new DataReader();
                            TableHomeDayDTO tableHomeDayDTO = dataReader.ReadTableHomeDayDTO(reader);
                            tableHomeDayDtoList.Add(tableHomeDayDTO);
                        }

                        IObjectConverter objConverted = new ObjectConverter();
                        var obj = objConverted.TableHomeDayJson(tableHomeDayDtoList);

                        return obj;
                    }
                }
            }
        }
    }
}
