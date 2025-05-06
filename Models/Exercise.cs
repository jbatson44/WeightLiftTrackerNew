using SQLite;

namespace WeightLiftTracker.Models
{
    public class Exercise
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Type { get; set; } 
    }
}
