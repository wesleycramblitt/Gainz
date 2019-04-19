using GainzWebAPI.Enums;
using GainzWebAPI.RoutineGeneration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GainzWebAPI.Models
{
    public class RepScheme
    {
        public (int,int) PrimarySetsReps { get; set; }

        //public (int,int) SecondarySetsReps { get; set; }

        public int TotalReps()
        {
            int reps = 0;

            for (int i = 0; i < PrimarySetsReps.Item1; i++)
            {
                reps += PrimarySetsReps.Item2;
            }

            return reps;
        }

        public void Generate(GeneratorSettings genSettings)
        {
            Random r = new Random();
            int reps = ((int)genSettings.repRange * 3) - r.Next(0, 2);

            int maxSets = (int)genSettings.variation;
            int minSets = 0;
            switch (maxSets)
            {
                case 3:
                    minSets = 1;
                    break;
                case 7:
                    minSets = 4;
                    break;
                case 10:
                    minSets = 8;
                    break;
            }

            int sets = r.Next(minSets, maxSets);
            PrimarySetsReps = (sets, reps);

        }
    }
}
