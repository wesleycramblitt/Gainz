using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GainzWebAPI.Models
{
    public enum Volume { Low=1, Medium=2, High=3}

    public class WorkoutRoutine
    {
        public string Name { get; set; }

        public Split Split { get; set; }

        public List<WorkoutDay> WorkoutDays { get; set; }

        public Volume Volume { get; set; }

        public Frequency Frequency { get; set; }

        public Intensity Intensity { get; set; }

    }
}