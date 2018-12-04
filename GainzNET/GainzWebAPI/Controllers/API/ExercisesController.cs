using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GainzWebAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace GainzWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly GainzDBContext _context;

        public ExercisesController(GainzDBContext context)
        {
            _context = context;
        }

        // GET: api/Exercises
        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<Exercise> GetExercises()
        {
            return _context.Exercises.Include(e => e.ExerciseMuscles).ThenInclude(e => e.muscle);
        }

        // GET: api/Exercises/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExercise([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exercise = await _context.Exercises.FindAsync(id);

            if (exercise == null)
            {
                return NotFound();
            }

            return Ok(exercise);
        }

        // PUT: api/Exercises/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExercise([FromRoute] int id, [FromBody] Exercise exercise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exercise.ExerciseID)
            {
                return BadRequest();
            }

            _context.Entry(exercise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExerciseExists(id))
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

        // POST: api/Exercises
        [HttpPost]
        public async Task<bool> PostExercise([FromBody] Exercise exercise)
        {
            if (!ModelState.IsValid)
            {
                return false;
            }

            _context.Exercises.Add(exercise);

            await _context.SaveChangesAsync();

            return true;
        }

        // DELETE: api/Exercises/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExercise([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exercise = await _context.Exercises.FindAsync(id);
            if (exercise == null)
            {
                return NotFound();
            }

            _context.Exercises.Remove(exercise);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

            return Ok(exercise);
        }

        private bool ExerciseExists(int id)
        {
            return _context.Exercises.Any(e => e.ExerciseID == id);
        }
    }
}