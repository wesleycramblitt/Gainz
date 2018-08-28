package wesleysapps.myapplication;
/**
 * Created by Wesley on 2/23/2017.
 */

public class Exercise {
    public String Name;
    public Muscle MuscleWorked;


    public Exercise(Muscle muscleWorked){
        this.MuscleWorked = muscleWorked;
    }

    public void Generate() {
        Name = RandomWorkout.GetRandomWorkout(MuscleWorked);
    }
}
