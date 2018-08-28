package wesleysapps.myapplication;
import java.lang.reflect.Array;
import java.util.ArrayList;
/**
 * Created by Wesley on 2/23/2017.
 */

public class Day {
    public ArrayList<Exercise> Exercises = new ArrayList<Exercise>();
    public int SetsPerBigMuscle;
    public int SetsPerSmallMuscle;
    public Muscle[] MusclesWorked;
    public int SetsPerExercise;
    public int Repeat;


    public Day (int setsPerBigMuscle, int setsPerSmallMuscle, int setsPerExercise,
                Muscle[] musclesWorked, int repeat) {
        this.SetsPerBigMuscle = setsPerBigMuscle;
        this.SetsPerSmallMuscle = setsPerSmallMuscle;
        this.SetsPerExercise = setsPerExercise;
        this.MusclesWorked = musclesWorked;
        this.Repeat = repeat;
    }


    public void Generate() {
        //for each muscle group
        for (int i = 0; i < MusclesWorked.length; i++) {
            int exercises = 0;
            //calculate number of exercises using muscles worked and sets per muscle
            //TODO potentially make more sophisticated
            //have sets with lower reps to meet rep number perfectly
            switch (Maps.MuscleSizeMap.get(MusclesWorked[i])) {
                case Large:
                    exercises = (int)Math.ceil(((double)SetsPerBigMuscle)/((double)SetsPerExercise)/Repeat);
                    break;
                case Small:
                    exercises = (int)Math.ceil(((double)SetsPerSmallMuscle)/((double)SetsPerExercise)/Repeat);
                    break;
            }
            for (int j = 0; j < exercises; j++) {
                Exercise e = new Exercise(MusclesWorked[i]);
                e.Generate();
                Exercises.add(e);
            }

        }
        Util.workoutsFromFile = new ArrayList<String>();


    }
}
