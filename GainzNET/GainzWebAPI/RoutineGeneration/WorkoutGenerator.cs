using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using GainzWebAPI.Models;

namespace GainzWebAPI.RoutineGeneration
{
    public class WorkoutGenerator
    {
        RepScheme RepScheme;

        bool PreferCompound;

        KeyValuePair<Muscle, int> MuscleToWork;

        List<Exercise> UsedExercises;

        public WorkoutGenerator(RepScheme repScheme, bool preferCompound,KeyValuePair<Muscle, int> muscleToWork, List<Exercise> usedExercises)
        {
            RepScheme = repScheme;

            PreferCompound = preferCompound;

            MuscleToWork = muscleToWork;

            UsedExercises = usedExercises;
        }

        public Workout Generate(GainzDBContext dbContext)
        {
            Workout workout = new Workout();

            //Find an Exercise in the database that works the current muscle and isn't used yet.
            //if prefercompound find one. else go for exercises that have a high muscle involvment
            Random r = new Random();
            List<Exercise> exercises = dbContext.Exercises.Where(e => e.IsCompound == PreferCompound &&
                                    e.ExerciseMuscles.FirstOrDefault(em => em.muscle == MuscleToWork.Key) != null).ToList();

            workout.Exercise = exercises.ElementAt(r.Next(exercises.Count()));

            workout.RepScheme = RepScheme;

            return workout;
        }
    }
}
