using GainzWebAPI.Enums;
using GainzWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzWebAPI.RoutineGeneration
{
    public  class GeneratorSettings
    {

        public  RepRange repRange { get; set; }

        public  Frequency frequency { get; set; }

       // public  Intensity intensity { get; set; }

        public  Volume volume { get; set; }

        public  int physiqueGoal { get; set; }

        public  int performanceGoal { get; set; }

        public  int experience { get; set; }


        public int volumePerDay { get; set; }

        public  ExerciseVariation? variation { get; set; }

        public  List<string> laggingMuscles { get; set; }

        public List<string> overDevelopedMuscles { get; set; }

        public List<ExerciseType> exerciseTypes { get; set; }
        
        public void Initialize()
        {
            if (variation == null)
                variation = ExerciseVariation.Medium;

            if (laggingMuscles == null) laggingMuscles = new List<string>();

            if (overDevelopedMuscles == null) overDevelopedMuscles = new List<string>();

            if (exerciseTypes == null)
            {
                exerciseTypes = new List<ExerciseType>();
                exerciseTypes.Add(ExerciseType.Barbell);
            }
            #region physiquePerformanceExperience
            //int repRangeInt;

            //int frequencyInt;

            //int intensityInt;

            //int volumeInt;
            /*  
    Volume
        1-60, 30
        3 -90 reps large muscles, 45 reps small
        5 -120, 60

    Intensity
        1-normal sets
        2- more muscles
        3- more muscles and shorter rest

    Frequency
        1- “
        2- “
        3- Hit muscles 3 times a week each
        4- “
        5-

        Rep range
        1-1-3, 3 min rest
        2-4-8, 90 sec rest
        3-8-12, 60 sec rest
        4-12-15 45 sec rest
        5- 15-30
*/

            //determine repRange, frequency, and Intensity from parameters
            /*
                         * Physique goal logic:
		            Lose fat - increase intensity, and increase frequency
		            1 intensity 3, frequency 5
		            2 intensity 2, frequency 4
		            3 rep range 3, intensity 1, frequency 4
		            4 rep range 3, intensity 1, frequency 3
		            5 rep range 3, intensity 1, frequency 2
		            Build Muscle – lower intensity, keep rep range around 8-12

	            Performance goal logic
		            Gain Strength – lower rep ranges, lower intensity
		            1 rep range 1, intensity 1
		            2 rep range 2, intensity 1
		            3 rep range 3, intensity 2
		            4 rep range 4, intensity 2
		            5 rep range 5, intensity 3
		            Gain Endurance – higher rep ranges, higher intensity
	            Experience logic
		            Direct link to volume parameter
            */
            //if (physiqueGoal < 1 || physiqueGoal > 5) { throw new Exception("Physique Goal out of range"); }

            //if (performanceGoal < 1 || performanceGoal > 5) { throw new Exception("Performance Goal out of range"); }

            //if (experience < 1 || experience > 3) { throw new Exception("Experience out of range"); }


            //switch (physiqueGoal)
            //{
            //    case 1:
            //        repRangeInt = 5;
            //        intensityInt = 3;
            //        frequencyInt = 3;
            //        break;
            //    case 2:
            //        repRangeInt = 4;
            //        intensityInt = 2;
            //        frequencyInt = 3;
            //        break;
            //    case 3:
            //        repRangeInt = 3;
            //        intensityInt = 1;
            //        frequencyInt = 2;
            //        break;
            //    case 4:
            //        repRangeInt = 3;
            //        intensityInt = 1;
            //        frequencyInt = 2;
            //        break;
            //    case 5:
            //        repRangeInt = 3;
            //        intensityInt = 1;
            //        frequencyInt = 1;
            //        break;
            //    default:
            //        repRangeInt = 3;
            //        intensityInt = 1;
            //        frequencyInt = 2;
            //        break;
            //}

            //switch (performanceGoal)
            //{
            //    case 1:
            //        repRangeInt = (repRangeInt + 1) / 2;
            //        intensityInt = (intensityInt + 1) / 2;
            //        break;
            //    case 2:
            //        repRangeInt = (repRangeInt + 2) / 2;
            //        intensityInt = (intensityInt + 1) / 2;
            //        break;
            //    case 3:
            //        repRangeInt = (repRangeInt + 3) / 2;
            //        intensityInt = (intensityInt + 2) / 2;
            //        break;
            //    case 4:
            //        repRangeInt = (repRangeInt + 4) / 2;
            //        intensityInt = (intensityInt + 2) / 2;
            //        break;
            //    case 5:
            //        repRangeInt = (repRangeInt + 5) / 2;
            //        intensityInt = (intensityInt + 3) / 2;
            //        break;
            //    default:
            //        break;
            //}

            //volumeInt = experience;


            //frequency = (Frequency)frequencyInt;
            //volume = (Volume)volumeInt;
            //intensity = (Intensity)intensityInt;
            //repRange = (RepRange)repRangeInt;
            #endregion

            volumePerDay = (int)volume / (int)frequency; 
        }

    }
}
