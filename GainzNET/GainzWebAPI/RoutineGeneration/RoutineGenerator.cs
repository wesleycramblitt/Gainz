using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GainzWebAPI.Enums;
using GainzWebAPI.Models;
using Microsoft.EntityFrameworkCore;



namespace GainzWebAPI.RoutineGeneration
{
    public class RoutineGenerator
    {
        public GeneratorSettings generatorSettings { get; set; }

        public RoutineGenerator(GeneratorSettings generatorSettings)
        {
            this.generatorSettings = generatorSettings;
        }



        public WorkoutRoutine Generate(GainzDBContext dbContext)
        {
            //TODO fix
            WorkoutRoutine workoutRoutine = new WorkoutRoutine();
            workoutRoutine.WorkoutDays = new List<WorkoutDay>();

            int frequency = (int)this.generatorSettings.frequency;

            var splits = dbContext.Splits
                .Include(x => x.SplitDays)
                .ThenInclude(x => x.Day)
                .ThenInclude(x => x.DaysMuscles)
                .ThenInclude(x => x.Muscle)
                .Where(x => x.Frequency == frequency).ToList();

            if (splits.Count() == 0)
            {
                throw new Exception("No workout split available with selected Frequency");
            }

            Random r = new Random();

            Split split = splits.ElementAt(r.Next(splits.Count()));

            workoutRoutine.Split = split;

            List<SplitDay> splitDays = workoutRoutine.Split.SplitDays.OrderBy(x => x.ID).ToList();

            RepScheme repScheme = new RepScheme();

            repScheme.Generate(generatorSettings);

            Dictionary<string, WorkoutDay> likeDays = new Dictionary<string, WorkoutDay>();

            foreach (SplitDay splitDay in splitDays)
            {

                WorkoutDayGenerator workoutDayGenerator = new WorkoutDayGenerator(repScheme, splitDay, generatorSettings);
                WorkoutDay workoutDay = likeDays.ContainsKey(splitDay.Day.Name) ? 
                    likeDays[splitDay.Day.Name] : workoutDayGenerator.Generate(dbContext);
                likeDays[splitDay.Day.Name] = workoutDay;
                workoutRoutine.WorkoutDays.Add(workoutDay);
            }

            return workoutRoutine;
        }
        

    }
}
