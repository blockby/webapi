using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BBBWebApiCodeFirst.Models;
using System.IO;
using Npgsql;
using System.Data;

namespace BBBWebApiCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MtcActivitiesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly string connectionString = "User ID = postgres; Password = postgres; Server = localhost; Port = 5432; Database = BlockDb; Integrated Security = true; Pooling = true;";
        

        public MtcActivitiesController(DataContext context)
        {
            _context = context;

        //    List<MtcActivity> Data = new List<MtcActivity>();

        //   // var reader = new StreamReader(@"E:\ASP.net\BlockByBlock\New_Data\Activity_MUCNW_example_SW7x24.csv");
        //    var reader = new StreamReader(@"E:\ASP.net\BlockByBlock\csv\mtc_activity.csv"); 

        //    int i = 0;
        //    while (!reader.EndOfStream)
        //    {
        //        var line = reader.ReadLine();
        //        var values = line.Split(',');

        //        if (i != 0)
        //        {


        //            MtcActivity single = new MtcActivity
        //            {
        //                IdAct= Convert.ToInt32(values[0]),
        //                ZoneAct = Convert.ToInt32(values[1]),
        //                CountAct = Convert.ToInt32(values[2]),
        //                HoursAct = Convert.ToInt32(values[3]),
        //                DaysAct = Convert.ToInt32(values[4]),
        //                Density = Convert.ToDecimal(values[5])

        //            };


        //            //if (values[2] == "MON")
        //            //    single.DaysAct = 1;
        //            //else if (values[2] == "TUE")
        //            //    single.DaysAct = 2;
        //            //else if (values[2] == "WED")
        //            //    single.DaysAct = 3;
        //            //else if (values[2] == "THU")
        //            //    single.DaysAct = 4;
        //            //else if (values[2] == "FRI")
        //            //    single.DaysAct = 5;
        //            //else if (values[2] == "SAT")
        //            //    single.DaysAct = 6;
        //            //else if (values[2] == "SUN")
        //            //    single.DaysAct = 7;

        //            Data.Add(single);

        //        }
        //        i++;
        //    }

        //    _context.MtcActivitys.AddRange(Data);           
        //    _context.SaveChanges();
        }

        // GET: api/MtcActivities
        [HttpGet]
        public IEnumerable<MtcActivity> GetMtcActivitys()
        {
            return _context.MtcActivitys;

        }


        [HttpGet("weeklyviews")]
        public IEnumerable<WeeklyView> WeeklyViews()
        {
            //string _selectString = "SELECT * from \"Mtcs\" limit 3";

            string _selectString = "SELECT c.\"Id\", c.\"Gid\", c.\"Area\",a.\"ZoneAct\",  SUM(a.\"CountAct\") AS people, b.\"IdDay\", b.\"NameDay\", a.\"HoursAct\" from \"MtcActivitys\" a " +
               "INNER JOIN \"Dayss\" b ON a.\"DaysAct\" = b.\"IdDay\" " +
               "INNER JOIN \"Mtcs\" c  ON a.\"ZoneAct\" = c.\"Gid\" " +
               "WHERE ST_Contains(c.\"Geom\", ST_GeomFromText('POINT(11.56330 48.18674)', 4326))= true " +
               "GROUP BY c.\"Id\", c.\"Gid\", a.\"ZoneAct\" ,b.\"IdDay\", b.\"NameDay\", a.\"HoursAct\" ORDER BY b.\"IdDay\",a.\"HoursAct\" ASC ";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<WeeklyView> weeklyViewsList = new List<WeeklyView>();

                        while (reader.Read())
                        {
                            WeeklyView weeklyView = ReadWeekly(reader);
                            weeklyViewsList.Add(weeklyView);

                        }
                        return weeklyViewsList;
                    }
                }
            }
            
        }


        private static WeeklyView ReadWeekly(IDataRecord reader)
        {
            int id = reader.GetInt32(0);
           int gid = reader.GetInt32(1);            
           decimal area = reader.GetDecimal(2);
            int zoneAct = reader.GetInt32(3);
            long people = reader.GetInt32(4);
            int idDay = reader.GetInt32(5);
            string nameDay =reader.GetString(6);
            int houreAct = reader.GetInt32(7);

            WeeklyView weeklyView = new WeeklyView
            {
                Gid = gid,
                Id = id,                
                Area = area,
                ZoneAct=zoneAct,
                People=people,
                IdDay=idDay,
                NameDay=nameDay,
                HoureAct=houreAct
            };
            return weeklyView;
        }



        [HttpGet("TopMaxViews")]
        public IEnumerable<Query17> TopMaxViews()
        {
            //string _selectString = "SELECT * from \"Mtcs\" limit 3";

            string _selectString = "SELECT b.\"Id\", b.\"Gid\", a.\"ZoneAct\",  SUM(a.\"CountAct\") AS people from \"MtcActivitys\" a " +               
               "INNER JOIN \"Mtcs\" b  ON a.\"ZoneAct\" = b.\"Gid\" " +               
               "GROUP BY b.\"Id\", b.\"Gid\", a.\"ZoneAct\" ORDER BY \"people\" DESC LIMIT 5 ";


//            SELECT b.gid, b.id,a.zone_act, SUM(a.count_act) AS people, b.geom
//           FROM mtc_activity a
//INNER JOIN mtc b ON a.zone_act = b.gid
//GROUP BY b.gid, b.id, a.zone_act, b.geom ORDER BY people DESC LIMIT 5


            //    using (var _data = new DataContext())
            //    {
            //        var Mt = _data.MtcActivitys.FromSql("SELECT IdAct,CountAct,HoursAct FROM MtcActivitys").ToArray();
            //        return Mt;
            //    }

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<Query17> TopMaxViewsList = new List<Query17>();

                        while (reader.Read())
                        {
                            Query17 TopMaxView = ReadTopMaxViews(reader);
                            TopMaxViewsList.Add(TopMaxView);

                        }
                        return TopMaxViewsList;
                    }
                }
            }
            
        }


        private static Query17 ReadTopMaxViews(IDataRecord reader)
        {
            int id = reader.GetInt32(0);
            int gid = reader.GetInt32(1);            
            int zoneAct = reader.GetInt32(2);
            long people = reader.GetInt32(3);
            

            Query17 TopMaxViews = new Query17
            {
                Gid = gid,
                Id = id,                
                ZoneAct = zoneAct,
                People = people                
            };
            return TopMaxViews;
        }





        // GET: api/MtcActivities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMtcActivity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mtcActivity = await _context.MtcActivitys.FindAsync(id);

            if (mtcActivity == null)
            {
                return NotFound();
            }

            return Ok(mtcActivity);
        }

        // PUT: api/MtcActivities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMtcActivity([FromRoute] int id, [FromBody] MtcActivity mtcActivity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mtcActivity.IdAct)
            {
                return BadRequest();
            }

            _context.Entry(mtcActivity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MtcActivityExists(id))
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

        // POST: api/MtcActivities
        [HttpPost]
        public async Task<IActionResult> PostMtcActivity([FromBody] MtcActivity mtcActivity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MtcActivitys.Add(mtcActivity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMtcActivity", new { id = mtcActivity.IdAct }, mtcActivity);
        }

        // DELETE: api/MtcActivities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMtcActivity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mtcActivity = await _context.MtcActivitys.FindAsync(id);
            if (mtcActivity == null)
            {
                return NotFound();
            }

            _context.MtcActivitys.Remove(mtcActivity);
            await _context.SaveChangesAsync();

            return Ok(mtcActivity);
        }

        private bool MtcActivityExists(int id)
        {
            return _context.MtcActivitys.Any(e => e.IdAct == id);
        }
    }
}