using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WeightLiftTracker.Models
{
    public class WorkoutExercise : ObservableCollection<WorkoutSet>
    {
        public int ExerciseId { get; set; }
        public string ExerciseName { get; set; }
        public int ExerciseType { get; set; }
        public WorkoutExercise(int id, string name, int type, ObservableCollection<WorkoutSet> list) : base(list)
        {
            ExerciseId = id;
            ExerciseName = name;
            ExerciseType = type;
        }
    }
    public class WorkoutSet
    {
        public WorkoutSet(string name, int type)
        {
            ExerciseName = name;
            ExerciseType = type;
            Reps = null;
            Weight = null;
        }
        public int Id { get; set; }
        public string ExerciseName { get; set; }
        public int ExerciseType { get; set; }


        public int? Reps { get; set; }
        public int? Weight { get; set; }
        public int? Minutes { get; set; }
        public int? Seconds { get; set; }
        public float? Distance { get; set; }
        public string Notes { get; set; }


        public int? PrevReps { get; set; }
        public int? PrevWeight { get; set; }
        public int? PrevMinutes { get; set; }
        public int? PrevSeconds { get; set; }
        public float? PrevDistance { get; set; }
        public string PrevNotes { get; set; }
    }
}
