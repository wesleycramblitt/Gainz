using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzWebAPI.Models
{
    public class SplitDayMuscle
    {
        public int ID { get; set; }

        public int SplitDayID { get; set; }

        public Muscle Muscle { get; set; }
    }
}
