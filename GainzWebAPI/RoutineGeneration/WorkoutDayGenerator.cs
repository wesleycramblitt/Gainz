using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using GainzWebAPI.Models;

namespace GainzWebAPI.RoutineGeneration
{
    public class WorkoutDayGenerator
    {
        readonly int VolumePerDay;

        RepScheme RepScheme;

        SplitDay SplitDay;

        Dictionary<Muscle, int> VolumeMuscleMap;
        readonly Random random = new Random();

        GeneratorSettings GeneratorSettings { get; set; }

        public WorkoutDayGenerator(RepScheme repScheme, SplitDay splitDay, GeneratorSettings _generatorSettings )
        {
            RepScheme = repScheme;

            SplitDay = splitDay;

            VolumePerDay = _generatorSettings.VolumePerDay;

            VolumeMuscleMap = new Dictionary<Muscle, int>();

            GeneratorSettings = _generatorSettings;
            
            //large muscles worked twice as much as small
            foreach (Muscle muscle in SplitDay.Day.DaysMuscles
                                                .OrderBy(x => x.ID)
                                                .ThenBy(x => x.Muscle.Size)
                                                .Select(x => x.Muscle))
            {
                if (GeneratorSettings.LaggingMuscles.Contains(muscle.Name))
                {
                    VolumeMuscleMap.Add(muscle, (VolumePerDay / muscle.Size)* 2);
                }
                else if (GeneratorSettings.OverDevelopedMuscles.Contains(muscle.Name))
                {
                    VolumeMuscleMap.Add(muscle, (VolumePerDay /muscle.Size)/2);
                }
                else
                {
                    VolumeMuscleMap.Add(muscle, VolumePerDay /muscle.Size);
                }

            }
        }

        public WorkoutDay Generate(GainzDBContext dbContext)
        {
            WorkoutDay workoutDay = new WorkoutDay(SplitDay.Day.IsRest, SplitDay.Day.Name)
            {
                Workouts = new List<Workout>()
            };

            List<Exercise> usedExercises = new List<Exercise>();

            //Rest Day
            if (VolumeMuscleMap.Count == 0)
            {
                return workoutDay;
            }

            WorkoutGenerator workoutGenerator = new WorkoutGenerator(RepScheme, VolumeMuscleMap.First().Key, GeneratorSettings);
            
            while (VolumeMuscleMap.Count > 0)
            {

                var muscle = VolumeMuscleMap.First().Key;
                var count = VolumeMuscleMap[muscle] / RepScheme.TotalReps();
                workoutGenerator.ExerciseCount = count == 0 ? 1 : count;

                workoutGenerator.MuscleToWork = muscle;
                var workouts = workoutGenerator.Generate(dbContext);


                foreach (var workout in workouts)
                {

                    foreach (var workedMuscle in workout.Exercise.ExerciseMuscles.Select(x => x.Muscle))
                    {
                        if (VolumeMuscleMap.ContainsKey(workedMuscle))
                        {
                            VolumeMuscleMap[workedMuscle] -= workout.TotalReps();
                            if (VolumeMuscleMap[workedMuscle] <= 0)
                            {
                                VolumeMuscleMap.Remove(workedMuscle);
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
