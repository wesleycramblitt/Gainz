package wesleysapps.myapplication;

import java.lang.reflect.Array;
import java.util.Collections;
import java.util.HashMap;
import java.util.Map;

/**
 * Created by Wesley on 2/23/2017.
 */

public class Maps {

    public static final Map<Integer, Split[]> DaySplitMap;
    static {
        Map<Integer, Split[]> daySplitMap = new HashMap<Integer, Split[]>();
        daySplitMap.put(1, new Split[] {Split.FullBody});
        daySplitMap.put(2, new Split[] {Split.FullBody, Split.PushPull, Split.UpperLower});
        daySplitMap.put(3, new Split[] {Split.FullBody, Split.PushPullLegs, Split.ChestBackLegs});
        daySplitMap.put(4, new Split[] { Split.PushPull, Split.UpperLower, Split.ChestBackArmsLegs });
        daySplitMap.put(5, new Split[] { Split.ChestBackArmsLegsShoulders});
        daySplitMap.put(6, new Split[] { Split.ChestBackArmsLegsShouldersAbs, Split.ChestBackBicepsTricepsLegsShoulders});
        daySplitMap.put(7, new Split[] {Split.ChestBackBicepsTricepsLegsShouldersAbs});

        DaySplitMap = Collections.unmodifiableMap(daySplitMap);
    }


    public static final Map<Integer, String[]> GoalRepSchemeMap;
    static {
        //Goal from 1 - 5 Strength to Size
        Map<Integer, String[]> goalRepSchemeMap = new HashMap<Integer, String[]>();
        goalRepSchemeMap.put(1, new String[] {  "5X5", "6X6", "9X3"});
        goalRepSchemeMap.put(2, new String[] {"8X8", "4X8", "3X8", "4X6"});
        goalRepSchemeMap.put(3, new String[] {"10/8/6/20", "10/8/6", "3X10"});
        goalRepSchemeMap.put(4, new String[] { "4X10", "3X10", "3X12"});
        goalRepSchemeMap.put(5, new String[] { "3X15", "10X10", "5X10"});

        GoalRepSchemeMap = Collections.unmodifiableMap(goalRepSchemeMap);
    }


    public static final Map<String, Integer> RepSchemeCountMap;
    static {
        //Goal from 1 - 5 Strength to Size
        Map<String, Integer> repSchemeCountMap = new HashMap<String, Integer>();
        repSchemeCountMap.put("5X5", 25);
        repSchemeCountMap.put("6X6", 36);
        repSchemeCountMap.put("10X5", 50);
        repSchemeCountMap.put("8X8", 64);
        repSchemeCountMap.put("4X8", 32);
        repSchemeCountMap.put("3X8", 24);
        repSchemeCountMap.put("4X6", 24);
        repSchemeCountMap.put("10/8/6/20", 44);
        repSchemeCountMap.put("10/8/6", 24);
        repSchemeCountMap.put("3X10", 30);
        repSchemeCountMap.put("4X10", 40);
        repSchemeCountMap.put("3X12", 36);
        repSchemeCountMap.put("3X15", 45);
        repSchemeCountMap.put("10X10", 100);
        repSchemeCountMap.put("5X10", 50);
        repSchemeCountMap.put("9X3", 27);

        RepSchemeCountMap = Collections.unmodifiableMap(repSchemeCountMap);
    }

    public static final Map<Integer, String> StrengthIntensityRestMap;
    static {
        //Goal from 1 - 5 Strength to Size
        Map<Integer, String> strengthIntensityRestMap = new HashMap<Integer, String>();
        strengthIntensityRestMap.put(1, "3 minutes");
        strengthIntensityRestMap.put(2, "2 minutes 30 seconds");
        strengthIntensityRestMap.put(3, "2 minutes");
        strengthIntensityRestMap.put(4, "1 minutes 30 seconds");
        strengthIntensityRestMap.put(5, "1 minutes");

        StrengthIntensityRestMap = Collections.unmodifiableMap(strengthIntensityRestMap);
    }

    public static final Map<Integer, String> SizeIntensityRestMap;
    static {
        //Goal from 1 - 5 Size to Size
        Map<Integer, String> sizeIntensityRestMap = new HashMap<Integer, String>();
        sizeIntensityRestMap.put(1, "90 seconds");
        sizeIntensityRestMap.put(2, "1 minute 15 seconds");
        sizeIntensityRestMap.put(3, "1 minutes");
        sizeIntensityRestMap.put(4, "45 seconds");
        sizeIntensityRestMap.put(5, "30 seconds");

        SizeIntensityRestMap = Collections.unmodifiableMap(sizeIntensityRestMap);
    }


    public static final Map<Integer, Integer> LargeIntensitySetCountMap;
    static {
        //Goal from 1 - 5 Size to Size
        Map<Integer, Integer> largeIntensitySetCountMap = new HashMap<Integer, Integer>();
        largeIntensitySetCountMap.put(1, 60);
        largeIntensitySetCountMap.put(2, 75);
        largeIntensitySetCountMap.put(3, 90);
        largeIntensitySetCountMap.put(4, 105);
        largeIntensitySetCountMap.put(5, 120);

        LargeIntensitySetCountMap = Collections.unmodifiableMap(largeIntensitySetCountMap);
    }

    public static final Map<Integer, Integer> SmallIntensitySetCountMap;
    static {
        //Goal from 1 - 5 Size to Size
        Map<Integer, Integer> smallIntensitySetCountMap = new HashMap<Integer, Integer>();
        smallIntensitySetCountMap.put(1, 30);
        smallIntensitySetCountMap.put(2, 38);
        smallIntensitySetCountMap.put(3, 46);
        smallIntensitySetCountMap.put(4, 54);
        smallIntensitySetCountMap.put(5, 60);

        SmallIntensitySetCountMap = Collections.unmodifiableMap(smallIntensitySetCountMap);
    }

//TODO divide lower back and abs from everything else
    public static final Map<Split, Muscle[][]> SplitDayMusclesMap;
    static {
        Map<Split, Muscle[][]> splitDayMusclesMap = new HashMap<Split, Muscle[][]>();
        splitDayMusclesMap.put(Split.FullBody, new Muscle[][]{ {Muscle.Chest, Muscle.Back, Muscle.Biceps, Muscle.Hamstrings, Muscle.Quadraceps, Muscle.Shoulders,
        Muscle.Triceps}});
        splitDayMusclesMap.put(Split.PushPull, new Muscle[][]{ {Muscle.Chest,  Muscle.Quadraceps, Muscle.Shoulders, Muscle.Triceps},
                {Muscle.Biceps, Muscle.Back, Muscle.Hamstrings}});
        splitDayMusclesMap.put(Split.ChestBackArmsLegs, new Muscle[][]{ {Muscle.Chest},{Muscle.Back},
                {Muscle.Biceps, Muscle.Triceps, Muscle.Shoulders}, {Muscle.Hamstrings, Muscle.Quadraceps}});
        splitDayMusclesMap.put(Split.ChestBackArmsLegsShoulders, new Muscle[][]{ {Muscle.Chest},{Muscle.Back},
                {Muscle.Biceps, Muscle.Triceps}, {Muscle.Hamstrings, Muscle.Quadraceps}, {Muscle.Shoulders}});
        splitDayMusclesMap.put(Split.ChestBackArmsLegsShouldersAbs, new Muscle[][]{ {Muscle.Chest},{Muscle.Back},
                {Muscle.Biceps, Muscle.Triceps}, {Muscle.Hamstrings, Muscle.Quadraceps}, {Muscle.Abs}});
        splitDayMusclesMap.put(Split.ChestBackBicepsTricepsLegsShoulders, new Muscle[][]{ {Muscle.Chest},{Muscle.Back},
                {Muscle.Biceps},{ Muscle.Triceps}, {Muscle.Hamstrings, Muscle.Quadraceps}});
        splitDayMusclesMap.put(Split.ChestBackBicepsTricepsLegsShouldersAbs, new Muscle[][]{ {Muscle.Chest},{Muscle.Back},
                {Muscle.Biceps},{ Muscle.Triceps}, {Muscle.Hamstrings, Muscle.Quadraceps},{Muscle.Shoulders}, {Muscle.Abs}});
        splitDayMusclesMap.put(Split.PushPullLegs, new Muscle[][]{ {Muscle.Chest,  Muscle.Shoulders, Muscle.Triceps},
                {Muscle.Biceps, Muscle.Back}, {Muscle.Quadraceps, Muscle.Hamstrings}});
        splitDayMusclesMap.put(Split.ChestBackLegs, new Muscle[][]{ {Muscle.Chest},
                { Muscle.Back}, { Muscle.Hamstrings, Muscle.Quadraceps}});
        splitDayMusclesMap.put(Split.UpperLower, new Muscle[][]{ {Muscle.Chest,  Muscle.Biceps, Muscle.Back, Muscle.Triceps},
                {Muscle.Quadraceps, Muscle.Hamstrings}});
        SplitDayMusclesMap = Collections.unmodifiableMap(splitDayMusclesMap);
    }

    public static final Map<Muscle, MuscleSize> MuscleSizeMap;
    static {
        Map<Muscle, MuscleSize> muscleSizeMap = new HashMap<Muscle, MuscleSize>();
        muscleSizeMap.put(Muscle.Back, MuscleSize.Large);
        muscleSizeMap.put(Muscle.Chest, MuscleSize.Large);
        //TODO better solution. I made quads and hams small because they were being overworked. Squats only counts for one or the other
        muscleSizeMap.put(Muscle.Quadraceps, MuscleSize.Small);
        muscleSizeMap.put(Muscle.Hamstrings, MuscleSize.Small);
        muscleSizeMap.put(Muscle.Triceps, MuscleSize.Small);
        muscleSizeMap.put(Muscle.Biceps, MuscleSize.Small);
        muscleSizeMap.put(Muscle.Abs, MuscleSize.Small);
        muscleSizeMap.put(Muscle.Shoulders, MuscleSize.Large);
        MuscleSizeMap = Collections.unmodifiableMap(muscleSizeMap);
    }
}
