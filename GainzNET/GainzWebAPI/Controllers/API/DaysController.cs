using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GainzWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GainzWebAPI.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DaysController : ControllerBase
    {
            private readonly GainzDBContext _context;

            public DaysController(GainzDBContext context)
            {
                _context = context;
            }

            // GET: api/Days
            [HttpGet]
            public IEnumerable<Day> GetDays()
            {
                return _context.Days.Include(x => x.DaysMuscles).ThenInclude(y => y.Muscle);
            }

            // GET: api/Days/5
            [HttpGet("{id}")]
            public async Task<IActionResult> GetDay([FromRoute] int id)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var Day = await _context.Days.FindAsync(id);

                if (Day == null)
                {
                    return NotFound();
                }

                return Ok(Day);
            }

            // PUT: api/Days/5
            [HttpPut("{id}")]
            public async Task<IActionResult> PutDay([FromRoute] int id, [FromBody] Day Day)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != Day.ID)
                {
                    return BadRequest();
                }

                try
                {
                var ctxDay = _context.Days.Include(x => x.DaysMuscles).ThenInclude(x => x.Muscle).
                    FirstOrDefault(x => x.ID == id);
                    AutoMapper.Mapper.Map(Day, ctxDay);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DayExists(id))
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

            // POST: api/Days
            [HttpPost]
            public async Task<IActionResult> PostDay([FromBody] Day Day)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _context.Days.Add(Day);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetDay", new { id = Day.ID }, Day);
            }

            // DELETE: api/Days/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteDay([FromRoute] int id)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var Day = await _context.Days.FindAsync(id);
                if (Day == null)
                {
                    return NotFound();
                }

                _context.Days.Remove(Day);
                await _context.SaveChangesAsync();

                return Ok(Day);
            }

            private bool DayExists(int id)
            {
                return _context.Days.Any(e => e.ID == id);
            }
        
    
}
}