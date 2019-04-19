using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzWebAPI.Models
{
    public class Workout
    {
        public Exercise Exercise { get; set; }

        public RepScheme RepScheme { get; set; }

        public int TotalReps(Muscle m = null)
        {
            int involvement = 1;
            if (m != null)
                involvement = Exercise.ExerciseMuscles.FirstOrDefault(x => x.Muscle == m).percentInvolvement;
            involvement = 1;
            int reps = RepScheme.TotalReps() * involvement;

            return reps;
        }
    }
}
