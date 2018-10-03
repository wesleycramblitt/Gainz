using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzWebAPI.Models
{
    public class ExerciseMuscle
    {
        public int ID { get; set; }

        public Muscle muscle { get; set; }

        public int percentInvolvement { get; set; }
    }
}
