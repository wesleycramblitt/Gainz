using GainzWebAPI.Enums;
using GainzWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzWebAPI.RoutineGeneration
{
    public class GeneratorSettings
    {
        //Basic Mode
        //public int physiqueGoal { get; set; }

        //public int performanceGoal { get; set; }

        //public int experience { get; set; }

        //Advanced Mode
        public int Frequency { get; set; }

        public int Volume { get; set; }

        public RepScheme RepScheme { get; set; }

        public List<string> LaggingMuscles { get; set; }

        public List<string> OverDevelopedMuscles { get; set; }

        public List<ExerciseType> ExerciseTypes { get; set; }


        //Calculated
        public int VolumePerDay {get; set;}
        
        public void Initialize()
        {
            if (LaggingMuscles == null) LaggingMuscles = new List<string>();

            if (OverDevelopedMuscles == null) OverDevelopedMuscles = new List<string>();

            if (ExerciseTypes == null)
            {
                ExerciseTypes = new List<ExerciseType>
                {
                    ExerciseType.Barbell
                };
            }

            VolumePerDay = (int)Volume / (int)Frequency; 
        }

    }
}
