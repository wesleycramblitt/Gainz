using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.ComponentModel;

namespace Gains.DataAccess
{
    public class Workout
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }

        public string PrimaryMuscle { get; set; }

        public string SecondaryMuscles { get; set; }

        public int IsCompound { get; set; }
    }
}
