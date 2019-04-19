using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using GainzWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GainzWebAPI.RoutineGeneration
{
    public class WorkoutGenerator
    {
        RepScheme RepScheme;

        Muscle MuscleToWork;

        List<Exercise> UsedExercises;

        GeneratorSettings GeneratorSettings;

        public WorkoutGenerator(RepScheme repScheme, Muscle muscleToWork, List<Exercise> usedExercises, GeneratorSettings genSettings)
        {
            RepScheme = repScheme;

            GeneratorSettings = genSettings;

            MuscleToWork = muscleToWork;

            UsedExercises = usedExercises;
        }

        public Workout Generate(GainzDBContext dbContext)
        {
            Workout workout = new Workout();

            //Find an Exercise in the database that works the current muscle and isn't used yet.
            //if prefercompound find one. else go for exercises that have a high muscle involvment
            Random r = new Random();
            List<Exercise> exercises = dbContext.Exercises
                .Except(UsedExercises)
                .Include(x => x.ExerciseMuscles)
                .ThenInclude(x => x.Muscle)
                .Where(e => e.ExerciseMuscles.FirstOrDefault(em => em.Muscle == MuscleToWork) != null &&
                GeneratorSettings.exerciseTypes.Contains(e.ExerciseType))
                .OrderBy(x => x.IsCompound == true)
                .ToList();

            if (exercises.Count() == 0)
            {
                throw new Exception("Ran out of exercises to match current settings.");
            }
            //TODO group by percentinvolvemnt?
            workout.Exercise = exercises.ElementAt(r.Next(exercises.Count()));

            workout.RepScheme = RepScheme;

            return workout;
        }
    }
}
