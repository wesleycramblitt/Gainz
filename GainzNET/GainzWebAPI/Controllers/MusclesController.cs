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
    public class MusclesController : ControllerBase
    {
        private readonly GainzDBContext _context;

        public MusclesController(GainzDBContext context)
        {
            _context = context;
        }

        // GET: api/Muscles
        [HttpGet]
        public IEnumerable<Muscle> GetMuscles()
        {
            return _context.Muscles;
        }

        // GET: api/Muscles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMuscle([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var muscle = await _context.Muscles.FindAsync(id);

            if (muscle == null)
            {
                return NotFound();
            }

            return Ok(muscle);
        }

        // PUT: api/Muscles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMuscle([FromRoute] int id, [FromBody] Muscle muscle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != muscle.ID)
            {
                return BadRequest();
            }

            _context.Entry(muscle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MuscleExists(id))
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

        // POST: api/Muscles
        [HttpPost]
        public async Task<IActionResult> PostMuscle([FromBody] Muscle muscle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Muscles.Add(muscle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMuscle", new { id = muscle.ID }, muscle);
        }

        // DELETE: api/Muscles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMuscle([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var muscle = await _context.Muscles.FindAsync(id);
            if (muscle == null)
            {
                return NotFound();
            }

            _context.Muscles.Remove(muscle);
            await _context.SaveChangesAsync();

            return Ok(muscle);
        }

        private bool MuscleExists(int id)
        {
            return _context.Muscles.Any(e => e.ID == id);
        }
    }
}