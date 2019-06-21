﻿using System;
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

        public Muscle MuscleToWork { get; set; }

        List<Workout> Workouts { get; set; }

        GeneratorSettings GeneratorSettings { get; set; }

        public int ExerciseCount { get; set; }
        
        List<Exercise> UsedExercises { get; set; }

        public WorkoutGenerator(RepScheme repScheme, Muscle muscleToWork,  GeneratorSettings genSettings, int exerciseCount = 1)
        {
            RepScheme = repScheme;

            GeneratorSettings = genSettings;

            MuscleToWork = muscleToWork;

            ExerciseCount = exerciseCount;

            UsedExercises = new List<Exercise>();
        }

        public List<Workout> Generate(GainzDBContext dbContext)
        {
            Workout workout = new Workout();


            //Find an Exercise in the database that works the current muscle and isn't used yet.
            //if prefercompound find one. else go for exercises that have a high muscle involvment
            
            List<Exercise> Exercises = dbContext.Exercises
                .Include(x => x.ExerciseMuscles)
                .ThenInclude(x => x.Muscle)
                .Where(e => e.ExerciseMuscles.FirstOrDefault(em => em.Muscle == MuscleToWork) != null &&
                GeneratorSettings.exerciseTypes.Contains(e.ExerciseType) &&
                !UsedExercises.Any(x => x.ExerciseID == e.ExerciseID)
                )
                .OrderBy(x => x.IsCompound == true)
                .ToList();
            
            var rnd = new Random();
            Exercises = Exercises.OrderBy(x => rnd.Next()).Take(ExerciseCount).ToList();

            

            if (Exercises.Count() == 0)
            {
                throw new Exception("Ran out of exercises to match current settings.");
            }
            Workouts = new List<Workout>();
            foreach (var exercise in Exercises)
            {
                Workouts.Add(new Workout { Exercise = exercise, RepScheme = RepScheme });
            }

            UsedExercises.AddRange(Exercises);

            return Workouts;
        }
    }
}