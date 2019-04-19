using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GainzWebAPI.Models;

namespace GainzWebAPI.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SplitDaysController : ControllerBase
    {
        private readonly GainzDBContext _context;

        public SplitDaysController(GainzDBContext context)
        {
            _context = context;
        }

        // GET: api/SplitDays
        [HttpGet]
        public IEnumerable<SplitDay> GetSplitDays()
        {
            return _context.SplitDays;
        }

        // GET: api/SplitDays/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSplitDay([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var splitDay = await _context.SplitDays.FindAsync(id);

            if (splitDay == null)
            {
                return NotFound();
            }

            return Ok(splitDay);
        }

        // PUT: api/SplitDays/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSplitDay([FromRoute] int id, [FromBody] SplitDay splitDay)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != splitDay.ID)
            {
                return BadRequest();
            }

            _context.Entry(splitDay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SplitDayExists(id))
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

        // POST: api/SplitDays
        [HttpPost]
        public async Task<IActionResult> PostSplitDay([FromBody] SplitDay splitDay)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SplitDays.Add(splitDay);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSplitDay", new { id = splitDay.ID }, splitDay);
        }

        // DELETE: api/SplitDays/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSplitDay([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var splitDay = await _context.SplitDays.FindAsync(id);
            if (splitDay == null)
            {
                return NotFound();
            }

            _context.SplitDays.Remove(splitDay);
            await _context.SaveChangesAsync();

            return Ok(splitDay);
        }

        private bool SplitDayExists(int id)
        {
            return _context.SplitDays.Any(e => e.ID == id);
        }
    }
}