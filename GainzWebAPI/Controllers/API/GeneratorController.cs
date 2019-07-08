using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GainzWebAPI.Models;
using GainzWebAPI.RoutineGeneration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GainzWebAPI.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneratorController : ControllerBase
    {
        private readonly GainzDBContext _context;

        public GeneratorController(GainzDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult GetWorkoutRoutine(GeneratorSettings generatorSettings)
        {
            generatorSettings.Initialize();

            var generator = new RoutineGeneration.RoutineGenerator(generatorSettings);
            try
            {
                var routine = generator.Generate(_context);

                return new JsonResult(routine);
            }
            catch (Exception ex)
            {
                WorkoutRoutine wr = new WorkoutRoutine();
                wr.failed = true;
                wr.failureMessage = ex.Message;
                return new JsonResult(wr);
            }
            
            
        }
    }

}