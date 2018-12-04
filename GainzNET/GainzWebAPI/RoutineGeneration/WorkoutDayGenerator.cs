using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using GainzWebAPI.Models;

namespace GainzWebAPI.RoutineGeneration
{
    public class WorkoutDayGenerator
    {

        int VolumePerDay;

        RepScheme RepScheme;

        SplitDay SplitDay;

        Dictionary<Muscle, int> volumeMuscleMap;

        Random random = new Random();

        public WorkoutDayGenerator(int volumePerDay, RepScheme repScheme, SplitDay splitDay )
        {
            RepScheme = repScheme;

            SplitDay = splitDay;

            VolumePerDay = volumePerDay;

            volumeMuscleMap = new Dictionary<Muscle, int>();

            //large muscles worked twice as much as small
            foreach (Muscle muscle in SplitDay.SplitDaysMuscles.Select(x => x.Muscle))
            {
                if (muscle.IsLarge)
                    volumeMuscleMap.Add(muscle, volumePerDay);
                else
                    volumeMuscleMap.Add(muscle, volumePerDay/2);
            }
        }

        public WorkoutDay Generate(GainzDBContext dbContext)
        {
            WorkoutDay workoutDay = new WorkoutDay(SplitDay.IsRest, SplitDay.Name);

            List<Exercise> exercises = new List<Exercise>();

            bool preferCompound = true;

            foreach (KeyValuePair<Muscle,int> muscleVolume in volumeMuscleMap)
            {
                while (muscleVolume.Value > 0)
                {
                    WorkoutGenerator workoutGenerator = new WorkoutGenerator(RepScheme, preferCompound, muscleVolume, exercises);

                    Workout workout = workoutGenerator.Generate(dbContext);
                    
                    volumeMuscleMap[muscleVolume.Key] -= workout.TotalReps(muscleVolume.Key);

                    workoutDay.Workouts.Add(workout);

                    if (preferCompound)
                    {
                        preferCompound = false;
                    }

                }
            }


            return workoutDay;
        }
    }
}
