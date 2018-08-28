package wesleysapps.myapplication;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.SeekBar;
import android.widget.TextView;
import android.widget.SeekBar.OnSeekBarChangeListener;
import android.widget.Toast;
import android.view.Menu;


public class MainActivity extends AppCompatActivity implements OnSeekBarChangeListener {

    SeekBar seekBar1;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        seekBar1=(SeekBar)findViewById(R.id.Days);
        seekBar1.setOnSeekBarChangeListener(this);

        Util.context = getApplicationContext();
    }

    @Override
    public void onProgressChanged(SeekBar seekBar, int progress,
                                  boolean fromUser) {
        //Toast.makeText(getApplicationContext(),"seekbar progress: "+progress, Toast.LENGTH_SHORT).show();

        ((TextView)findViewById(R.id.NumberOfDays)).setText(String.valueOf(progress+ 3));
    }
    @Override
    public void onStartTrackingTouch(SeekBar seekBar) {
        //Toast.makeText(getApplicationContext(),"seekbar touch started!", Toast.LENGTH_SHORT).show();
    }
    @Override
    public void onStopTrackingTouch(SeekBar seekBar) {
        //Toast.makeText(getApplicationContext(),"seekbar touch stopped!", Toast.LENGTH_SHORT).show();
    }
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        //getMenuInflater().inflate(R.menu.main, menu);
        return true;
    }

    public void generate(View view) {
        SeekBar days = (SeekBar)findViewById(R.id.Days);
        SeekBar goal = (SeekBar)findViewById(R.id.Goal);
        SeekBar intensity = (SeekBar)findViewById(R.id.Intensity);
        Workout w = new Workout(days.getProgress()+3,intensity.getProgress()+1, goal.getProgress()+1);
        w.Generate();
        Util.workout = w.print();

        // Start NewActivity.class
        Intent myIntent = new Intent(MainActivity.this,
                WorkoutActivity.class);
        startActivity(myIntent);
        //Toast.makeText(getApplicationContext(), w.print(), Toast.LENGTH_LONG).show();
    }
}
