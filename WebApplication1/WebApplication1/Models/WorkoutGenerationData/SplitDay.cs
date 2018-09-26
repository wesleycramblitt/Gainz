using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzWebAPI.Models
{
    public class SplitDay
    {
        public string name;
        public bool isRest;
        public List<Muscle> musclesWorked;
    }
}
