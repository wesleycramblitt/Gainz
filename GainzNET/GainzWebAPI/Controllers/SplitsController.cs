using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GainzWebAPI.Models;

namespace GainzWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SplitsController : ControllerBase
    {
        private readonly GainzDBContext _context;

        public SplitsController(GainzDBContext context)
        {
            _context = context;
        }

        // GET: api/Splits
        [HttpGet]
        public IEnumerable<Split> GetSplits()
        {
            return _context.Splits;
        }

        // GET: api/Splits/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSplit([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var split = await _context.Splits.FindAsync(id);

            if (split == null)
            {
                return NotFound();
            }

            return Ok(split);
        }

        // PUT: api/Splits/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSplit([FromRoute] int id, [FromBody] Split split)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != split.ID)
            {
                return BadRequest();
            }

            _context.Entry(split).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SplitExists(id))
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

        // POST: api/Splits
        [HttpPost]
        public async Task<IActionResult> PostSplit([FromBody] Split split)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Splits.Add(split);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSplit", new { id = split.ID }, split);
        }

        // DELETE: api/Splits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSplit([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var split = await _context.Splits.FindAsync(id);
            if (split == null)
            {
                return NotFound();
            }

            _context.Splits.Remove(split);
            await _context.SaveChangesAsync();

            return Ok(split);
        }

        private bool SplitExists(int id)
        {
            return _context.Splits.Any(e => e.ID == id);
        }
    }
}