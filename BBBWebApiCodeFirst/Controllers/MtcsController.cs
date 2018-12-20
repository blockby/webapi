using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BBBWebApiCodeFirst.Models;
using NetTopologySuite.Geometries;
using Npgsql;
using System.IO;
using System.Data;

namespace BBBWebApiCodeFirst.Controllers
{
    [Route("api/Mtcs")]
    [ApiController]
    public class MtcsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly string connectionString= "User ID = postgres; Password = postgres; Server = localhost; Port = 5432; Database = BlockDb; Integrated Security = true; Pooling = true;";

        public MtcsController(DataContext context)
        {
            _context = context;

        }

        // GET: api/Mtcs
        [HttpGet]
        public IEnumerable<Mtc> GetMtcs()
        {
            return _context.Mtcs;
        }



        ////GET:api/Mtcs/getallrows
        [HttpGet("getallrows")]
        public IEnumerable<Mtc> GetAllRows()
        {
             string _selectString = "SELECT * from \"Mtcs\" limit 3";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<Mtc> MtcList = new List<Mtc>();

                        while (reader.Read())
                        {
                            Mtc mtc = ReadMtc(reader);
                            MtcList.Add(mtc);
                            
                        }
                        return MtcList;
                    }
                }
            }
            
        }

        
        private static Mtc ReadMtc(IDataRecord reader)
        {
            int gid = reader.GetInt32(0);
            long id = reader.GetInt64(1);
            long groesse = reader.GetInt64(2);            
            Geometry geom = reader.GetValue(3) as NetTopologySuite.Geometries.Geometry;
            decimal area = reader.GetDecimal(4);

            Mtc mtc = new Mtc
            {
                Gid = gid,
                Id = id,
                Groesse = groesse, 
                Geom=geom,
                Area = area
            };
            return mtc;
        }


        ////GET:api/Mtcs/getallrows
        //[HttpGet("getallrows")]
        //public IEnumerable<Mtc> GetAllRows()
        //{
        //string _selectString = "SELECT * from \"Mtcs\" limit 3";

        // string _selectString = "SELECT * from \"Mtcs\" limit 3";

        //            SELECT c.id, c.gid, c.area,a.zone_act, b.id_day,b.name_day, a.hours_act, SUM(a.count_act) AS people, c.geom FROM mtc_activity a
        //INNER JOIN days b ON a.days_act = b.id_day
        //INNER JOIN mtc c  ON a.zone_act = c.gid
        //WHERE ST_Contains(c.geom, ST_GeomFromText('POINT(11.56330 48.18674)', 4326))= true
        //GROUP BY c.id, c.gid, a.zone_act, b.id_day, b.name_day, a.hours_act, c.geom ORDER BY b.id_day,a.hours_act ASC

        //    using (var conn = new NpgsqlConnection(connectionString))
        //    {
        //        conn.Open();

        //        using (var cmd = new NpgsqlCommand(_selectString, conn))
        //        {
        //            using (var reader = cmd.ExecuteReader())
        //            {
        //                List<Mtc> MtcList = new List<Mtc>();

        //                while (reader.Read())
        //                {
        //                    Mtc mtc = ReadMtc(reader);
        //                    MtcList.Add(mtc);
        //                }
        //                return MtcList;
        //            }
        //        }
        //    }
        //    //return null;
        //}

        //private static Mtc ReadMtc(IDataRecord reader)
        //{
        //    int gid = reader.GetInt32(0);
        //    long id = reader.GetInt64(1);
        //    long groesse = reader.GetInt64(2);
        //    decimal area = reader.GetDecimal(4);

        //    Mtc mtc = new Mtc
        //    {
        //        Gid = gid,
        //        Id = id,
        //        Groesse = groesse,
        //        Area = area
        //    };
        //    return mtc;
        //}

        // GET: api/Mtcs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMtc([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mtc = await _context.Mtcs.FindAsync(id);

            if (mtc == null)
            {
                return NotFound();
            }

            return Ok(mtc);
        }

        // GET: api/Mtcs/GetArea/id
        [HttpGet("getarea/{id}")]
        public async Task<IActionResult> GetArea([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // var mtc = await _context.Mtcs.FindAsync(id);

            var mtc = await _context.Mtcs.FindAsync(id);
            var mtcArea = mtc.Area;

            if (mtcArea == null)
            {
                return NotFound();
            }

            return Ok(mtcArea);
        }


        // GET: api/Mtcs/gettophour
        //[HttpGet("gettophour")]
        //public async Task<IActionResult> GetTopHour()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

            //var tophour =  _context.Mtcs.
            
            //if (tophour == null)
            //{
            //    return NotFound();
            //}

            //return Ok(tophour);
        //}


        // PUT: api/Mtcs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMtc([FromRoute] int id, [FromBody] Mtc mtc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mtc.Gid)
            {
                return BadRequest();
            }

            _context.Entry(mtc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MtcExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Mtcs
        [HttpPost]
        public async Task<IActionResult> PostMtc([FromBody] Mtc mtc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Mtcs.Add(mtc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMtc", new { id = mtc.Gid }, mtc);
        }

        // DELETE: api/Mtcs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMtc([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mtc = await _context.Mtcs.FindAsync(id);
            if (mtc == null)
            {
                return NotFound();
            }

            _context.Mtcs.Remove(mtc);
            await _context.SaveChangesAsync();

            return Ok(mtc);
        }

        private bool MtcExists(int id)
        {
            return _context.Mtcs.Any(e => e.Gid == id);
        }
    }
}