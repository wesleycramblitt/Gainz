using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzWebAPI.Models
{
    public class RepSchemeSet
    {
        public int ID { get; set; }

        public int Reps { get; set; }

        public int Percent1RM { get; set; }

        public int RestInterval { get; set; }
    }
}
