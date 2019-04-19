using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzWebAPI.Models
{
    public class DayMuscle
    {
        public int ID { get; set; }

        public int DayID { get; set; }

        public Muscle Muscle { get; set; }
    }
}
