using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzWebAPI.Models
{

    public enum Frequency { One=1, Two=2, Three=3, Four=4, Five=5 }

    public class Split
    {
        public int ID { get; set; }

        public string Name { get; set;}

        public List<SplitDay> SplitDays { get; set;}

        public Frequency Frequency { get; set;}

        public Intensity Intensity { get; set; }
    }
}
