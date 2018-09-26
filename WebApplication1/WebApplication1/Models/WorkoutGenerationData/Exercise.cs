using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzWebAPI.Models
{
    public class Exercise
    {
        string name;
        //Create a type attribute
        List<ExerciseMuscle> exerciseMuscles;
        bool isCompound;
    }
}
