using System;
using System.Collections.Generic;
using System.Text;
using Gains.Models;
using SQLite;
using Xamarin.Forms;


namespace Gains.DataAccess
{
    public static class GainsDatabase
    {
        private static SQLiteAsyncConnection database;
        public static SQLiteAsyncConnection Database
        {

            get
            {
                return (database == null) ?  new SQLiteAsyncConnection(DependencyService.Get<IFileHelper>().GetLocalFilePath("Gainz.db")) : database;
            }
        }


        public static int GetRepsPerWeek(int volume)
        {
            const int MAXVOLUME = 20;

            //60 - 120 reps scaled
            return (volume / MAXVOLUME) * 60 + 60;
        }

        //Rest Interval and rep scheme
        public static RepScheme GetRepScheme(int strengthendurance)
        {
            return database.GetAsync<RepScheme>("Select * From RepScheme Where StrengthEnduranceFactor =" + strengthendurance + " Order By RANDOM() LIMIT 1").Result;
        }

        public static Split GetSplit(int split)
        {
            return database.GetAsync<Split>("Select * From Split Where NumberOfDays =" + split + " Order By RANDOM() LIMIT 1").Result;
        }


        public static List<Models.Workout> GetDayWorkouts(Day day, int repCount)
        {
            List<Models.Workout> workouts = new List<Models.Workout>();

            Dictionary<string, string> muscles = new Dictionary<string, string>();
            muscles.Add("Chest", "Primary");
            muscles.Add("Back", "Primary");
            muscles.Add("Triceps", "Secondary");
            muscles.Add("Biceps", "Secondary");
            muscles.Add("Quadriceps", "Primary");
            muscles.Add("Hamstrings", "Secondary");
            muscles.Add("Shoulders", "Secondary");
            muscles.Add("Traps", "Secondary");

            //All the challenging work is here. 
            //Must meet sets per muscle as closely as possible by using repscheme and also factoring in secondary muscles worked
            //For example: Bench press works shoulders and triceps secondarily. Use half the set count when factoring in secondary muscles
            foreach (Muscle m in day.MusclesWorked)
            {
                int musclereps = Convert.ToInt32(day.RepsPerDay);
                if (muscles[m.Name] == "Secondary")
                {
                    musclereps = musclereps / 2;
                }

                int numberOfWorkoutsPerMuscle = (int)(musclereps / repCount);

                for (int i = 0; i < numberOfWorkoutsPerMuscle; i++)
                {
                    Models.Workout workout = new Models.Workout();

                    DataAccess.Workout workoutModel = database.GetAsync<DataAccess.Workout>("Select * From Workout where PrimaryMuscle = '" + m.Name + "' Order By Random() Limit 1").Result;

                    workout.Name = workoutModel.Name;

                    workouts.Add(workout);
                }
                
                
            }

            return workouts;
        }


        public static void SaveRoutine(Routine routine)
        {
            throw new NotImplementedException();
        }

        public static List<Routine> GetRoutineHistory ()
        {
            throw new NotImplementedException();
        }

        public static string GetRandomName()
        {
            throw new NotImplementedException();
        }
    }
}