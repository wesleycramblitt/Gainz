using GainzWebAPI.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GainzWebAPI.Models
{


    public class WorkoutRoutine
    {
        public string Name { get; set; }

        public Split Split { get; set; }

        public List<WorkoutDay> WorkoutDays { get; set; }

        public Volume Volume { get; set; }

        public Frequency Frequency { get; set; }

       // public Intensity Intensity { get; set; }

        public string Display
        {
            get
            {
                var display = "";
                foreach (var wd in WorkoutDays)
                {
                    display += "<h2>"+wd.Name+"</h2>";
                    foreach (var w in wd.Workouts)
                    {
                        display+= w.Exercise.Name + " "+ w.RepScheme.PrimarySetsReps.Item1.ToString()
                            +"X" + w.RepScheme.PrimarySetsReps.Item2.ToString() + "<br/>";

                    }
                }
                return display;
            }

            set { }
        }

    }
}