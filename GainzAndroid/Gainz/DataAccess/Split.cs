using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.ComponentModel;

namespace Gains.DataAccess
{
    public class Split
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }

        public int NumberOfDays { get; set; }

        public string Day1Name { get; set; }

        public string Day1Muscles { get; set; }

        public string Day2Name { get; set; }

        public string Day2Muscles { get; set; }

        public string Day3Name { get; set; }

        public string Day3Muscles { get; set; }

        public string Day4Name { get; set; }

        public string Day4Muscles { get; set; }

        public string Day5Name { get; set; }

        public string Day5Muscles { get; set; }

        public string Day6Name { get; set; }

        public string Day6Muscles { get; set; }

        public string Day7Name { get; set; }

        public string Day7Muscles { get; set; }
    }
}
