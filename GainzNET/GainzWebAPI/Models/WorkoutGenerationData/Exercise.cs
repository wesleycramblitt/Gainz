using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzWebAPI.Models
{
    public enum ExerciseType { BodyweightNoEquipment, BodyweightEquipment, Barbell, Dumbbell, Kettlebell, Cables, Machine }
    public class Exercise
    {
        public int ID { get; set; }

        public string Name{ get; set;}

        public ExerciseType ExerciseType { get; set; }


        public List<ExerciseMuscle> ExerciseMuscles{ get; set;}

        public bool IsCompound{ get; set;}
    }
}
