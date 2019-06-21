using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzWebAPI.Models
{
    public class Workout
    {
        public Workout ()
        {
            _totalReps = null;
        }
        public Exercise Exercise { get; set; }

        public RepScheme RepScheme { get; set; }

        public int TotalReps(Muscle m = null)
        {


            if (_totalReps == null)
            {
                int involvement = 1;
                //if (m != null)
                //involvement = Exercise.ExerciseMuscles.FirstOrDefault(x => x.Muscle == m).percentInvolvement;

                int reps = RepScheme.TotalReps() * involvement;
                _totalReps = reps;
            }

            return _totalReps.Value;
        }
  
        private int? _totalReps { get; set; }
    }
}
