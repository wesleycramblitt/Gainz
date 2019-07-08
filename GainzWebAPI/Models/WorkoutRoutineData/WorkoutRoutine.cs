using GainzWebAPI.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GainzWebAPI.Models
{


    public class WorkoutRoutine
    {
        public string Name { get; set; }

        public List<WorkoutDay> WorkoutDays { get; set; }

        public string SplitName { get; set; }

        public int Volume { get; set; }

        public int Frequency { get; set; }

        public RepScheme RepScheme { get; set; }

        public List<string> ExerciseTypes { get; set; }

        public bool failed { get; set; }

        public string failureMessage { get; set; }

    }
}