using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using GainzWebAPI.Models;

namespace GainzWebAPI.RoutineGeneration
{
    public class WorkoutGenerator
    {
        int reps;

        int sets;

        bool preferCompound;

        KeyValuePair<Muscle, int> muscleToWork;

        List<Exercise> usedExercises;

        public WorkoutGenerator(int _reps, int _sets, bool _preferCompound,KeyValuePair<Muscle, int> _muscleToWork, List<Exercise> _usedExercises)
        {
            reps = _reps;
            sets = _sets;
            preferCompound = _preferCompound;
            muscleToWork = _muscleToWork;
            usedExercises = _usedExercises;
        }

        public Workout Generate()
        {
            Workout workout = new Workout();

            workout.reps = reps;
            workout.sets = sets;


            //Find an Exercise in the database that works the current muscle and isn't used yet.
            //if prefercompound find one. else go for exercises that have a high muscle involvment


            return workout;
        }
    }
}
