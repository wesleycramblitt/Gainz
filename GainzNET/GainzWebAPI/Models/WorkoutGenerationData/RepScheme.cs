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
        public RepScheme()
        {
            _totalReps = null;
        }
        public (int,int) PrimarySetsReps { get; set; }

        //public (int,int) SecondarySetsReps { get; set; }

        private int? _totalReps { get; set; }
        public int TotalReps()
        {
            if (_totalReps == null)
            {
                _totalReps = (PrimarySetsReps.Item1) * (PrimarySetsReps.Item2);
            }
            return _totalReps.Value;
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
