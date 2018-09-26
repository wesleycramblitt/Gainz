using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace GainzWebAPI.Models
{
    public class WorkoutDay
    {
        public bool isRest;
        public string name;
        public List<Workout> workouts;

        public WorkoutDay(bool _isRest, string _name)
        {
            isRest = _isRest;
            name = _name;
        }


        int totalReps()
        {
            throw new NotImplementedException();
        }
    }
}