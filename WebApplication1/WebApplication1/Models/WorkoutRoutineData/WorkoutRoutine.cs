using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GainzWebAPI.Models
{
    public class WorkoutRoutine
    {
        public int intensity, volume, repRange, frequency;
        public string name;
        public Split split;
        public List<WorkoutDay> workoutDays;

        public WorkoutRoutine(int _intensity, int _volume, int _repRange, int _frequency)
        {
            intensity = _intensity;
            volume = _volume;
            repRange = _repRange;
            frequency = _frequency;

        }

        public void determineSplit()
        {
            //TODO code to select split where frequency matches
            
        }
    }
}