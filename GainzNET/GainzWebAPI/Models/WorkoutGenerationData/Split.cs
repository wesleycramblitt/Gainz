using GainzWebAPI.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static GainzWebAPI.RoutineGeneration.GeneratorSettings;

namespace GainzWebAPI.Models
{
    public class Split
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Name { get; set;}

        public string Description { get; set; }

        public int Frequency { get; set; }

        public List<SplitDay> SplitDays { get; set;}

      
    }
}
