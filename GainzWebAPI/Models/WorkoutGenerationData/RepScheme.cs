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

        public int Reps { get; set; } 
        public int Sets { get; set; }


        public int TotalReps()
        {
            return Reps * Sets;
        }

    }
}
