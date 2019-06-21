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
                                                .OrderBy(x => x.Muscle.Size)
                                                .Select(x => x.Muscle))
            {
                if (generatorSettings.laggingMuscles.Contains(muscle.Name))
                {
                    volumeMuscleMap.Add(muscle, (VolumePerDay / ((muscle.isLarge) ? 1 : 2))* 2);
                }
                else if (generatorSettings.overDevelopedMuscles.Contains(muscle.Name))
                {
                    volumeMuscleMap.Add(muscle, (VolumePerDay / ((muscle.isLarge) ? 1 : 2))/2);
                }
                else
                {
                    volumeMuscleMap.Add(muscle, VolumePerDay /((muscle.isLarge)? 1 : 2));
                }

            }
        }

        public WorkoutDay Generate(GainzDBContext dbContext)
        {
            WorkoutDay workoutDay = new WorkoutDay(SplitDay.Day.IsRest, SplitDay.Day.Name);
            workoutDay.Workouts = new List<Workout>();
            List<Exercise> usedExercises = new List<Exercise>();

            //Res Day
            if (volumeMuscleMap.Count == 0)
            {
                return workoutDay;
            }

            WorkoutGenerator workoutGenerator = new WorkoutGenerator(RepScheme, volumeMuscleMap.First().Key, generatorSettings);
            
            while (volumeMuscleMap.Count > 0)
            {

                var muscle = volumeMuscleMap.First().Key;
                var count = volumeMuscleMap[muscle] / RepScheme.TotalReps();
                workoutGenerator.ExerciseCount = count == 0 ? 1 : count;

                workoutGenerator.MuscleToWork = muscle;
                var workouts = workoutGenerator.Generate(dbContext);


                foreach (var workout in workouts)
                {

                    foreach (var workedMuscle in workout.Exercise.ExerciseMuscles.Select(x => x.Muscle))
                    {
                        if (volumeMuscleMap.ContainsKey(workedMuscle))
                        {
                            volumeMuscleMap[workedMuscle] -= workout.TotalReps();
                            if (volumeMuscleMap[workedMuscle] <= 0)
                            {
                                volumeMuscleMap.Remove(workedMuscle);
                            }
                        }
                    }
                }

                workoutDay.Workouts.AddRange(workouts);

            }


            


            return workoutDay;
            
        }
    }
}
