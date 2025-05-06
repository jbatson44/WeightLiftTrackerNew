using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeightLiftTracker.Models
{
    class RoutineExerciseGroups
    {
        [ForeignKey(typeof(Routine))]
        public int RoutineId { get; set; }

        [ForeignKey(typeof(Exercise))]
        public int ExerciseId { get; set; }
        public int GoalSetNumber { get; set; }
    }
}
