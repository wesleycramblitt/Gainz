using System;
using System.Collections.Generic;
using System.Text;

namespace Gains.Models
{
    public class Day
    {
        public string Name { get; set; }
        public List<Muscle> MusclesWorked { get; set; }
        public Boolean IsRest { get; set; }
        public string RepsPerDay { get; set; }
        public List<Workout> Workouts { get; set; }
    }
}
