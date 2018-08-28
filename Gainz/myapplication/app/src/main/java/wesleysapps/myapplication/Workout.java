package wesleysapps.myapplication;
import java.util.ArrayList;
import java.util.Random;

/**
 * Created by Wesley on 2/23/2017.
 */

public class Workout {
    public ArrayList<Day> Days = new ArrayList<Day>();
    public String Name;
    public int DaysInGym;
    public int Intensity;
    public int Goal; //Scale from Size to Strength
    public String Rest;
    public int SmallGroupSets;
    public int LargeGroupSets;
    public Muscle[][] MuscleGroups;
    public Split Split;
    public int SetsPerExercise;
    public String RepScheme;
    public Workout (int daysinGym, int intensity, int goal) {
        this.DaysInGym = daysinGym;
        this.Intensity = intensity;
        this.Goal = goal;
    }

    public void Generate() {
        //pick random name
        Name = RandomName.generate();

        //pick split based on days and random selection
        Split[] splits = Maps.DaySplitMap.get(DaysInGym);
        Random r = new Random();
        Split = splits[r.nextInt(splits.length)];

        //pick rep scheme based on  goal
        String[] repSchemes = Maps.GoalRepSchemeMap.get(Goal);
        r = new Random();
        RepScheme = repSchemes[r.nextInt(repSchemes.length)];
        //Get sets per exercise based on rep scheme
        SetsPerExercise = Maps.RepSchemeCountMap.get(RepScheme);

        //pick rest intervals based on intensity and goal
        switch (Goal){
            case 1:
            case 2:
                Rest = Maps.StrengthIntensityRestMap.get(Intensity);
                break;
            case 3:
            case 4:
            case 5:
                Rest = Maps.SizeIntensityRestMap.get(Intensity);
                break;
        }

        //pick number of sets per muscle group
        SmallGroupSets = Maps.SmallIntensitySetCountMap.get(Intensity);
        LargeGroupSets = Maps.LargeIntensitySetCountMap.get(Intensity);

        //Get Muscles worked by split
        MuscleGroups = Maps.SplitDayMusclesMap.get(Split);
        int repeat = DaysInGym/MuscleGroups.length; //For repeat days. For example full body 3 times in one week
        for (int i = 0 ; i < DaysInGym; i++) {
            //repeat workouts
            Muscle[] muscleGroup;

            if (i > MuscleGroups.length-1)
            {
                muscleGroup = MuscleGroups[(((i+1) - MuscleGroups.length)/(i/MuscleGroups.length))-1];
            }
            else
            {
                muscleGroup = MuscleGroups[i];
            }
            Day d = new Day(LargeGroupSets, SmallGroupSets, SetsPerExercise, muscleGroup, repeat);
            d.Generate();
            Days.add(d);
        }
    }


    public String print() {
        String out = "";
        out += Name +"\n";
        out += "Rest "+Rest + "\n";
        out += Split + "\n";
        for (int i = 0; i < Days.size(); i++) {
            Day d = Days.get(i);
            out += "Day "+ (i+1)+ " "+"\n";
            for (int j = 0; j < d.Exercises.size(); j++) {
                Exercise e = d.Exercises.get(j);
                out +=e.Name + " " + RepScheme + "\n";
            }
            out += "\n";
        }
        out += "\n";

        return out;
    }

}
