using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GainzWebAPI.Enums;
using GainzWebAPI.Models;
using Microsoft.EntityFrameworkCore;

using GainzWebAPI.NameGenerator;

namespace GainzWebAPI.RoutineGeneration
{
    public class RoutineGenerator
    {
        public GeneratorSettings GeneratorSettings { get; set; }

        public RoutineGenerator(GeneratorSettings generatorSettings)
        {
            this.GeneratorSettings = generatorSettings;
        }



        public WorkoutRoutine Generate(GainzDBContext dbContext)
        {

            WorkoutRoutine workoutRoutine = new WorkoutRoutine
            {
                WorkoutDays = new List<WorkoutDay>()
            };

            int frequency = (int)this.GeneratorSettings.Frequency;
            RepScheme repScheme = this.GeneratorSettings.RepScheme;

            workoutRoutine.Frequency = frequency;
            workoutRoutine.Volume = this.GeneratorSettings.Volume;
            workoutRoutine.RepScheme = repScheme;
            workoutRoutine.ExerciseTypes = this.GeneratorSettings.ExerciseTypes.Select(x => EnumLabelLookup.ExerciseTypeLabels[x]).ToList();
            workoutRoutine.Name = NameGenerator.NameGenerator.getName();
          


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

            workoutRoutine.SplitName = split.Name;

            List<SplitDay> splitDays = split.SplitDays.OrderBy(x => x.ID).ToList();


            Dictionary<string, WorkoutDay> likeDays = new Dictionary<string, WorkoutDay>();

            foreach (SplitDay splitDay in splitDays)
            {

                WorkoutDayGenerator workoutDayGenerator = new WorkoutDayGenerator(repScheme, splitDay, GeneratorSettings);
                WorkoutDay workoutDay = likeDays.ContainsKey(splitDay.Day.Name) ? 
                    likeDays[splitDay.Day.Name] : workoutDayGenerator.Generate(dbContext);
                likeDays[splitDay.Day.Name] = workoutDay;
                workoutRoutine.WorkoutDays.Add(workoutDay);
            }

            return workoutRoutine;
        }
        

    }
}
