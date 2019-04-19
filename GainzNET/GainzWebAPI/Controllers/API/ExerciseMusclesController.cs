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
    public class ExerciseMusclesController : ControllerBase
    {
        private readonly GainzDBContext _context;

        public ExerciseMusclesController(GainzDBContext context)
        {
            _context = context;
        }

        // GET: api/ExerciseMuscles
        [HttpGet]
        public IEnumerable<ExerciseMuscle> GetExerciseMuscles()
        {
            return _context.ExerciseMuscles;
        }

        // GET: api/ExerciseMuscles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExerciseMuscle([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exerciseMuscle = await _context.ExerciseMuscles.FindAsync(id);

            if (exerciseMuscle == null)
            {
                return NotFound();
            }

            return Ok(exerciseMuscle);
        }

        // PUT: api/ExerciseMuscles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExerciseMuscle([FromRoute] int id, [FromBody] ExerciseMuscle exerciseMuscle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exerciseMuscle.ExerciseMuscleID)
            {
                return BadRequest();
            }

            _context.Entry(exerciseMuscle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExerciseMuscleExists(id))
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

        // POST: api/ExerciseMuscles
        [HttpPost]
        public async Task<IActionResult> PostExerciseMuscle([FromBody] ExerciseMuscle exerciseMuscle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ExerciseMuscles.Add(exerciseMuscle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExerciseMuscle", new { id = exerciseMuscle.ExerciseMuscleID }, exerciseMuscle);
        }

        // DELETE: api/ExerciseMuscles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExerciseMuscle([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exerciseMuscle = await _context.ExerciseMuscles.FindAsync(id);
            if (exerciseMuscle == null)
            {
                return NotFound();
            }

            _context.ExerciseMuscles.Remove(exerciseMuscle);
            await _context.SaveChangesAsync();

            return Ok(exerciseMuscle);
        }

        private bool ExerciseMuscleExists(int id)
        {
            return _context.ExerciseMuscles.Any(e => e.ExerciseMuscleID == id);
        }
    }
}