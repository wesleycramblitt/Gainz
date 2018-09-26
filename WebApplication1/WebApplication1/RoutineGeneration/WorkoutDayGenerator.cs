using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using GainzWebAPI.Models;

namespace GainzWebAPI.RoutineGeneration
{
    public class WorkoutDayGenerator
    {
        int reps;

        int sets;

        int workoutCount;

        int volumePerDay;

        SplitDay splitDay;

        Dictionary<Muscle, int> volumeMuscleMap;

        Random random = new Random();

        public WorkoutDayGenerator(int _volumePerDay, int _repRange, SplitDay _splitDay )
        {
            //TODO create ability to have varying sets and reps in workouts
            reps = random.Next( _repRange-4, _repRange); // choose desired reps randomly in range

            sets = random.Next(2, _volumePerDay / reps); // choose desired sets randomly in range

            splitDay = _splitDay;

            volumePerDay = _volumePerDay;

            foreach (Muscle muscle in _splitDay.musclesWorked)
            {
                if (muscle.isLarge)
                    volumeMuscleMap.Add(muscle, volumePerDay);
                else
                    volumeMuscleMap.Add(muscle, volumePerDay/2);
            }
        }

        public WorkoutDay Generate()
        {
            WorkoutDay workoutDay = new WorkoutDay(splitDay.isRest, splitDay.name);

            List<Exercise> exercises = new List<Exercise>();

            bool preferCompound;

            foreach (KeyValuePair<Muscle,int> muscleVolume in volumeMuscleMap)
            {
                while (muscleVolume.Value > 0)
                {
                    if ((muscleVolume.Key.isLarge && muscleVolume.Value == volumePerDay) ||
                        (!muscleVolume.Key.isLarge && muscleVolume.Value == volumePerDay/2))
                    {
                        preferCompound = true;
                    }
                    else
                    {
                        preferCompound = false;
                    }


                    WorkoutGenerator workoutGenerator = new WorkoutGenerator(reps, sets, preferCompound, muscleVolume, exercises);

                    Workout workout = workoutGenerator.Generate();

                    volumeMuscleMap[muscleVolume.Key] -= workout.totalReps();

                    workoutDay.workouts.Add(workout);

                }
            }


            return workoutDay;
        }
    }
}
