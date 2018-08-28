package wesleysapps.myapplication;

import android.content.Context;
import android.content.res.AssetManager;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;
import java.util.Random;

/**
 * Created by Wesley on 2/23/2017.
 */

public class RandomWorkout {

    public static String GetRandomWorkout( Muscle muscle) {
        String file = "";
        try {
            AssetManager am = Util.context.getAssets();
            InputStream is = am.open("exercises.txt");
            BufferedReader r = new BufferedReader(new InputStreamReader(is));
            StringBuilder total = new StringBuilder();
            String line;
            while ((line = r.readLine()) != null) {
                total.append(line).append('_');
            }
            file = total.toString();
        }
        catch (IOException ex) {}

        String[] fileSplit = file.split("_");
        List<String> workouts = new ArrayList<String>();
        //find all lines with chest
        for (int i = 0; i <fileSplit.length; i+=2) {
            if (fileSplit[i].contains(muscle.toString()))
            {
                if (!Util.workoutsFromFile.contains(fileSplit[i+1]))
                {
                    workouts.add(fileSplit[i + 1]);

                }
            }
        }

        Random r = new Random();
        String w = workouts.get(r.nextInt(workouts.size()));
        Util.workoutsFromFile.add(w);
        return w;

    }
}
