using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Gains.DataAccess
{
    public class RepScheme
    {
        public string Name { get; set; }

        public int StrengthEnduranceFactor { get; set; }

        public string RestInterval { get; set; }

        public int RepCount { get; set; }
    }
}
