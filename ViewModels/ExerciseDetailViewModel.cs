using System.Collections.ObjectModel;
using WeightLiftTracker.Models;

namespace WeightLiftTracker.ViewModels
{
    [QueryProperty(nameof(ExerciseId), "exerciseId")]
    public class ExerciseDetailViewModel : BaseViewModel
    {
        public string ExerciseId
        {
            set => LoadEverything(value);
        }
        public Exercise Exercise { get; set; }
        public ObservableCollection<Set> LastWorkout { get; set; }
        public async void LoadEverything(string exerciseId)
        {
            Exercise = await App.Database.GetExerciseById(int.Parse(exerciseId));
            Title = Exercise.Name;
            SetLastWorkoutStats(int.Parse(exerciseId));
        }
        public void OnAppearing()
        {
        }

        private async void SetLastWorkoutStats(int exerciseId)
        {
            var lastWorkoutSets = await App.Database.GetLastWorkoutStatsByExerciseId(exerciseId);
            foreach (var set in lastWorkoutSets)
            {
                LastWorkout.Add(set);
            }
        }

        public ExerciseDetailViewModel()
        {
            LastWorkout = new ObservableCollection<Set>();
        }
    }
}