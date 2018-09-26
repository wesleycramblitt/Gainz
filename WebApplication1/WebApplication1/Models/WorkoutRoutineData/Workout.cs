using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzWebAPI.Models
{
    public class Workout
    {
        public Exercise exercise;

        public int sets;

        public int reps;

        public int percent1RM;

        public int totalReps()
        {
            return sets * reps;
        }
    }
}
