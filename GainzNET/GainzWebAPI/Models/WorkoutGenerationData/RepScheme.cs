using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzWebAPI.Models
{
    public enum RepRange { MaxStrength=1, Strength=2, HypertrophyStrengh=3, Hypertrophy=4, Endurance=5 }
    
    public enum Intensity { Low=1, Medium=2, High=3}

    public class RepScheme
    {
        public int ID { get; set; }

        public RepRange RepRange { get; set; }

        public Intensity Intensity { get; set; }

        public List<RepSchemeSet> RepSchemeSets { get; set; }

        public int TotalReps()
        {
            int reps = 0;

            foreach (RepSchemeSet set in RepSchemeSets)
            {
                reps += set.Reps;
            }

            return reps;
        }
    }
}
