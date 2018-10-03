using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzWebAPI.Models
{
    public class SplitDay
    {
        public int ID { get; set; }

        public string Name { get; set;}

        public bool IsRest { get; set;}

        public List<Muscle> MusclesWorked { get; set;}
    }
}
