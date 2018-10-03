using System;
using System.Collections.Generic;
using System.Text;

namespace Gains.Models
{
    public class Routine
    {

        public string SplitName;

        public List<Day> Days { get; set; }

        public string Name;

        public string RepScheme;

        public string RestInterval;

        public int RepsPerWeek;

        //Factor of 1-10
        //1 being pure strength 
        //10 being pure endurance (the ability to do several reps)
        public int StrengthEndurance;

        //Factor of 1-10
        //1 being very low volume 60 reps on big muscles and 30 on small muscles
        //10 being very high volume 90 reps on big and 60 on small 
        public int Volume;

        public int SplitNumber;

        public Routine(int volume, int strengthEndurance, int splitNumber)
        {
            Volume = volume;
            StrengthEndurance = strengthEndurance;
            SplitNumber = splitNumber;
        }
        

    }
}
