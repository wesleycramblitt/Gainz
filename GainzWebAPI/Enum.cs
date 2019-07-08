using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzWebAPI.Enums
{
    public enum RepRange { MaxStrength = 1, Strength = 2, HypertrophyStrengh = 3, Hypertrophy = 4, Endurance = 5 }
    public enum ExerciseType { BodyweightNoEquipment, BodyweightEquipment, Barbell, Dumbbell, Kettlebell, Cables, Machine }

    public static class EnumLabelLookup
    {
        public static Dictionary<ExerciseType, string> ExerciseTypeLabels =
            new Dictionary<ExerciseType, string>()
                {
                    {  ExerciseType.BodyweightNoEquipment, "Bodyweight" },
                    { ExerciseType.BodyweightEquipment, "Bodyweight with equipment" },
                    { ExerciseType.Cables, "Cables" },
                    { ExerciseType.Dumbbell, "Dumbbells" },
                    { ExerciseType.Machine, "Machines" },
                    { ExerciseType.Barbell, "Barbells" },
                    { ExerciseType.Kettlebell, "Kettlebells" }
                };
    }
}
