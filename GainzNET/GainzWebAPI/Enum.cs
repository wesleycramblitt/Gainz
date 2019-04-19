using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzWebAPI.Enums
{
    public enum RepRange { MaxStrength = 1, Strength = 2, HypertrophyStrengh = 3, Hypertrophy = 4, Endurance = 5 }
    public enum ExerciseType { BodyweightNoEquipment, BodyweightEquipment, Barbell, Dumbbell, Kettlebell, Cables, Machine }
    public enum ExerciseVariation { Low=3, Medium=7, High=10 }
    public enum Frequency { One = 1, Two = 2, Three = 3, Four = 4, Five = 5 }
   // public enum Intensity { Low = 1, Medium = 2, High = 3 }
    public enum Volume { VeryLow=60, Low = 75, Medium = 90, High=105, VeryHigh = 120 }

}
