using System;
using System.Collections.Generic;
using System.Text;
using Gains.Models;
using Gains.DataAccess;
using System.Collections;


namespace Gains.Logic
{
    public class RoutineGenerator
    {
        Routine Routine;

        public Routine Generate(int volume, int strengthendurance, int splitnumber)
        {
            Routine = new Routine(volume, strengthendurance, splitnumber);

            RepScheme repScheme = GainsDatabase.GetRepScheme(Routine.StrengthEndurance);
            Routine.RepScheme = repScheme.Name;

            Routine.RestInterval = repScheme.RestInterval;

            Routine.RepsPerWeek = GainsDatabase.GetRepsPerWeek(Routine.Volume);

            Split split = GainsDatabase.GetSplit(Routine.SplitNumber);
            Routine.SplitName = split.Name;

            Routine.Days = new List<Day>();

            #region daymappingcode
            if (split.Day1Name != null)
            {
                Day d = new Day();
                d.IsRest = (split.Day1Name == "Rest") ? true : false;

                //Calculate from repsperweek and the number of workouts
                d.RepsPerDay = (Routine.RepsPerWeek / split.NumberOfDays).ToString();

                foreach (string muscle in split.Day1Muscles.Split(','))
                {
                    Muscle m = new Muscle();
                    m.Name = muscle;

                    d.MusclesWorked.Add(m);
                    
                    
                }
                Routine.Days.Add(d);
                
            }

            if (split.Day2Name != null)
            {
                Day d = new Day();
                d.IsRest = (split.Day2Name == "Rest") ? true : false;
                if (!d.IsRest)
                {
                    //Calculate from repsperweek and the number of workouts
                    d.RepsPerDay = (Routine.RepsPerWeek / split.NumberOfDays).ToString();

                    foreach (string muscle in split.Day2Muscles.Split(','))
                    {
                        Muscle m = new Muscle();
                        m.Name = muscle;

                        d.MusclesWorked.Add(m);


                    }
                }
                Routine.Days.Add(d);

            }

            if (split.Day3Name != null)
            {
                Day d = new Day();
                d.IsRest = (split.Day3Name == "Rest") ? true : false;
                if (!d.IsRest)
                {
                    //Calculate from repsperweek and the number of workouts
                    d.RepsPerDay = (Routine.RepsPerWeek / split.NumberOfDays).ToString();

                    foreach (string muscle in split.Day3Muscles.Split(','))
                    {
                        Muscle m = new Muscle();
                        m.Name = muscle;

                        d.MusclesWorked.Add(m);


                    }
                }
                Routine.Days.Add(d);

            }

            if (split.Day4Name != null)
            {
                Day d = new Day();
                d.IsRest = (split.Day4Name == "Rest") ? true : false;
                if (!d.IsRest)
                {
                    //Calculate from repsperweek and the number of workouts
                    d.RepsPerDay = (Routine.RepsPerWeek / split.NumberOfDays).ToString();

                    foreach (string muscle in split.Day4Muscles.Split(','))
                    {
                        Muscle m = new Muscle();
                        m.Name = muscle;

                        d.MusclesWorked.Add(m);


                    }
                }
                Routine.Days.Add(d);

            }

            if (split.Day5Name != null)
            {
                Day d = new Day();
                d.IsRest = (split.Day5Name == "Rest") ? true : false;
                if (!d.IsRest)
                {
                    //Calculate from repsperweek and the number of workouts
                    d.RepsPerDay = (Routine.RepsPerWeek / split.NumberOfDays).ToString();

                    foreach (string muscle in split.Day5Muscles.Split(','))
                    {
                        Muscle m = new Muscle();
                        m.Name = muscle;

                        d.MusclesWorked.Add(m);


                    }
                }
                Routine.Days.Add(d);

            }

            if (split.Day6Name != null)
            {
                Day d = new Day();
                d.IsRest = (split.Day6Name == "Rest") ? true : false;
                if (!d.IsRest)
                {
                    //Calculate from repsperweek and the number of workouts
                    d.RepsPerDay = (Routine.RepsPerWeek / split.NumberOfDays).ToString();

                    foreach (string muscle in split.Day6Muscles.Split(','))
                    {
                        Muscle m = new Muscle();
                        m.Name = muscle;

                        d.MusclesWorked.Add(m);


                    }
                }
                Routine.Days.Add(d);

            }

            if (split.Day7Name != null)
            {
                Day d = new Day();
                d.IsRest = (split.Day7Name == "Rest") ? true : false;
                if (!d.IsRest)
                {
                    //Calculate from repsperweek and the number of workouts
                    d.RepsPerDay = (Routine.RepsPerWeek / split.NumberOfDays).ToString();

                    foreach (string muscle in split.Day7Muscles.Split(','))
                    {
                        Muscle m = new Muscle();
                        m.Name = muscle;

                        d.MusclesWorked.Add(m);


                    }
                }
                Routine.Days.Add(d);

            }

            foreach (Day d in Routine.Days)
            {
                if (!d.IsRest)
                {
                    d.Workouts = GainsDatabase.GetDayWorkouts(d, Convert.ToInt32(d.RepsPerDay));
                }

            }


            #endregion

            Routine.Name = GainsDatabase.GetRandomName();

            return Routine;
            

        }
    }
}
