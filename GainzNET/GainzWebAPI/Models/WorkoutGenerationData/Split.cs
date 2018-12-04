using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GainzWebAPI.Models
{

    public enum Frequency { One=1, Two=2, Three=3, Four=4, Five=5 }

    public class Split
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Name { get; set;}

        public string Description { get; set; }

        public List<SplitDay> SplitDays { get; set;}

        public Frequency Frequency { get; set;}

        public Intensity Intensity { get; set; }
    }
}
