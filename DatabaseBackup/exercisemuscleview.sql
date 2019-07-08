SELECT
	E.Name,
	MU.Name
FROM
   public."Exercises" as E
INNER JOIN public."ExerciseMuscles" as EM ON E.ExerciseID = EM.ExerciseID
INNER JOIN public."Muscles" as MU ON MU.ID = EM.MuscleID