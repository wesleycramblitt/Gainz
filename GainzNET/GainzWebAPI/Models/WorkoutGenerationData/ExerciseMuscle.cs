using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GainzWebAPI.Models
{
    public class ExerciseMuscle
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExerciseMuscleID { get; set; }

        public Muscle muscle { get; set; }

        public int percentInvolvement { get; set; }

        public int ExerciseID { get; set; }
    }
}
