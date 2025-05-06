using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WeightLiftTracker.Models
{
    public class ExerciseList : ObservableCollection<Exercise>
    {
        public ExerciseList(string category, ObservableCollection<Exercise> list) : base(list)
        {
            Category = category;
        }
        public string Category { get; set; }
    }
}
