using SQLite;
using System;

namespace WeightLiftTracker.Models
{
    public class Workout
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int RoutineId { get; set; }
        public string RoutineName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan Duration { get; set; }
        public bool Finished { get; set; }
    }
}
