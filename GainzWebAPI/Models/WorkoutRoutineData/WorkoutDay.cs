using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace GainzWebAPI.Models
{
    public class WorkoutDay
    {
        public bool IsRest { get; set; }

        public string Name { get; set; }

        public List<Workout> Workouts { get; set; }

        public WorkoutDay(bool isRest, string name)
        {
            IsRest = isRest;
            Name = name;
        }


        public int TotalReps()
        {
            int reps = 0;

            foreach (Workout w in Workouts)
            {
                reps += w.RepScheme.TotalReps();
            }

            return reps;
        }
    }
}