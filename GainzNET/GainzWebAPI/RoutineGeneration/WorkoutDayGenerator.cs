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

        GeneratorSettings generatorSettings { get; set; }

        public WorkoutDayGenerator(RepScheme repScheme, SplitDay splitDay, GeneratorSettings _generatorSettings )
        {
            RepScheme = repScheme;

            SplitDay = splitDay;

            VolumePerDay = _generatorSettings.volumePerDay;

            volumeMuscleMap = new Dictionary<Muscle, int>();

            generatorSettings = _generatorSettings;
            
            //large muscles worked twice as much as small
            foreach (Muscle muscle in SplitDay.Day.DaysMuscles
                                                .OrderByDescending(x => x.Muscle.Size)
                                                .Select(x => x.Muscle))
            {
                if (generatorSettings.laggingMuscles.Contains(muscle.Name))
                {
                    volumeMuscleMap.Add(muscle, VolumePerDay*2 / muscle.Size);
                }
                else if (generatorSettings.overDevelopedMuscles.Contains(muscle.Name))
                {
                    volumeMuscleMap.Add(muscle, (VolumePerDay/2) / muscle.Size);
                }
                else
                {
                    volumeMuscleMap.Add(muscle, VolumePerDay / muscle.Size);
                }

            }
        }

        public WorkoutDay Generate(GainzDBContext dbContext)
        {
            WorkoutDay workoutDay = new WorkoutDay(SplitDay.Day.IsRest, SplitDay.Day.Name);
            workoutDay.Workouts = new List<Workout>();

            List<Exercise> exercises = new List<Exercise>();

            
            while (volumeMuscleMap.Count > 0)
            {
                WorkoutGenerator workoutGenerator = new WorkoutGenerator(RepScheme, volumeMuscleMap.First().Key, exercises, generatorSettings);

                Workout workout = workoutGenerator.Generate(dbContext);

                exercises.Add(workout.Exercise);

                foreach (var exerciseMuscle in workout.Exercise.ExerciseMuscles)
                {
                    if (volumeMuscleMap.Keys.Contains(exerciseMuscle.Muscle))
                    {
                        volumeMuscleMap[exerciseMuscle.Muscle] -= workout.TotalReps(exerciseMuscle.Muscle);
                        if (volumeMuscleMap[exerciseMuscle.Muscle] <= 0)
                        {
                            volumeMuscleMap.Remove(exerciseMuscle.Muscle);
                        }
                    }
                }
                workoutDay.Workouts.Add(workout);

            }


            return workoutDay;
            
        }
    }
}
