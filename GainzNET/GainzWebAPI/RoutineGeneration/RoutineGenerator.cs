using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using GainzWebAPI.Models;

namespace GainzWebAPI.RoutineGeneration
{
    public class RoutineGenerator
    {
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

        int repRange;

        int frequency;

        int intensity;

        int volume;

        RepRange RepRange;

        Intensity Intensity;

        Volume Volume;

        Frequency Frequency;

        public RoutineGenerator(int physiqueGoal, int performanceGoal, int experience)
        {
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
            if (physiqueGoal < 1 || physiqueGoal > 5) { throw new Exception("Physique Goal out of range"); }

            if (performanceGoal < 1 || performanceGoal > 5) { throw new Exception("Performance Goal out of range"); }

            if (experience < 1 || experience > 3) { throw new Exception("Experience out of range"); }


            switch (physiqueGoal)
            {
                case 1:
                    intensity = 3;
                    frequency = 5;
                    break;
                case 2:
                    intensity = 2;
                    frequency = 4;
                    break;
                case 3:
                    repRange = 3;
                    intensity = 1;
                    frequency = 4;
                    break;
                case 4:
                    repRange = 3;
                    intensity = 1;
                    frequency = 3;
                    break;
                case 5:
                    repRange = 3;
                    intensity = 1;
                    frequency = 2;
                    break;
                default:
                    repRange = 3;
                    intensity = 1;
                    frequency = 4;
                    break;
            }

            switch (performanceGoal)
            {
                case 1:
                    repRange =  (repRange + 1)/2;
                    intensity = (intensity + 1)/2;
                    break;
                case 2:
                    repRange = (repRange + 2)/2;
                    intensity = (intensity + 1)/2;
                    break;
                case 3:
                    repRange = (repRange + 3)/2;
                    intensity = (intensity + 2)/2;
                    break;
                case 4:
                    repRange = (repRange + 4)/2;
                    intensity = (intensity + 2)/2;
                    break;
                case 5:
                    repRange = (repRange + 5)/2;
                    intensity = (intensity + 3)/2;
                    break;
                default:
                    break;
            }

            volume = experience;


            Frequency = (Frequency)frequency;
            Volume = (Volume)volume;
            Intensity = (Intensity)intensity;


        }



        public WorkoutRoutine Generate(GainzDBContext dbContext)
        {
            //TODO fix
            WorkoutRoutine workoutRoutine = new WorkoutRoutine();

            var splits = dbContext.Splits.Where(s => s.Intensity == Intensity && s.Frequency == Frequency).ToList();

            Random r = new Random();

            Split split = splits.ElementAt(r.Next(splits.Count()));

            workoutRoutine.Split = split;

            List<SplitDay> splitDays = workoutRoutine.Split.SplitDays;

            foreach (SplitDay splitDay in splitDays)
            {
                int volumePerDay = ((volume-1)*30+60) / frequency;

                var repSchemes = dbContext.RepSchemes.Where(x => x.RepRange == RepRange && x.Intensity == Intensity).ToList();

                RepScheme repScheme = repSchemes.ElementAt(r.Next(repSchemes.Count()));

                WorkoutDayGenerator workoutDayGenerator = new WorkoutDayGenerator(volumePerDay, repScheme, splitDay);

                workoutRoutine.WorkoutDays.Add(workoutDayGenerator.Generate(dbContext));
            }

            return workoutRoutine;
        }
        

    }
}
