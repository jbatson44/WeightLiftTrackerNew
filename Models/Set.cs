using SQLite;
using SQLiteNetExtensions.Attributes;
using System;

namespace WeightLiftTracker.Models
{
    public class Set
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int ExerciseId { get; set; }
        public string ExerciseName { get; set; }
        public int ExerciseType { get; set; }
        public int WorkoutId { get; set; }
        public int SetNumber { get; set; }


        public int? Reps { get; set; }
        public int? Weight { get; set; }

        // cardio
        public int? Minutes { get; set; }
        public int? Seconds { get; set; }
        public float? Distance { get; set; }


        public string Notes { get; set; }
    }
}
