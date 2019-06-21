using GainzWebAPI.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GainzWebAPI.Models
{
    public class Exercise
    {
        public Exercise()
        {
            ExerciseMuscles =  new List<ExerciseMuscle>();
        }

        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExerciseID { get; set; }

        public string Name{ get; set;}

        public ExerciseType ExerciseType { get; set; }

        public List<ExerciseMuscle> ExerciseMuscles{ get; set;}

        public bool IsCompound{ get; set;}
    }
}
