using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzWebAPI.Models
{
    public class Split
    {
        public string Name;
        public List<SplitDay> splitDays;
        public int frequency;
    }
}
