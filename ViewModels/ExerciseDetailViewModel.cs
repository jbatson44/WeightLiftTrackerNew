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
        int oneRepMaxEpley = 0;
        public int OneRepMaxEpley
        {
            get { return oneRepMaxEpley; }
            set { SetProperty(ref oneRepMaxEpley, value); }
        }
        int oneRepMaxBrzycki = 0;
        public int OneRepMaxBrzycki
        {
            get { return oneRepMaxBrzycki; }
            set { SetProperty(ref oneRepMaxBrzycki, value); }
        }
        public async void LoadEverything(string exerciseId)
        {
            Exercise = await App.Database.GetExerciseById(int.Parse(exerciseId));
            Title = Exercise.Name;
            SetLastWorkoutStats(int.Parse(exerciseId));
            SetOneRepMaxEstimate();
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

        private async void SetOneRepMaxEstimate()
        {
            var highestWeightSet = await App.Database.GetHighestWeightSet(Exercise.Id);
            if (highestWeightSet != null)
            {
                var weight = highestWeightSet.Weight ?? 0;
                var reps = highestWeightSet.Reps ?? 0;
                OneRepMaxEpley = (int)(weight * (1 + reps / 30.0));
                OneRepMaxBrzycki = (int)(weight * (36.0 / (37 - reps)));
            }
        }

        public ExerciseDetailViewModel()
        {
            LastWorkout = new ObservableCollection<Set>();
        }
    }
}