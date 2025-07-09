using SQLite;
using SQLiteNetExtensions.Attributes;

namespace WeightLiftTracker.Models
{
    public class Routine
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [ManyToMany(typeof(Exercise))]
        public List<Exercise> Exercises { get; set; }
        public string Name { get; set; }
    }
}