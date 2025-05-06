using System.Collections.ObjectModel;
using System.Diagnostics;
using WeightLiftTracker.Models;

namespace WeightLiftTracker.ViewModels
{
    [QueryProperty(nameof(WorkoutId), "workoutId")]
    public class PreviousWorkoutViewModel : BaseViewModel
    {
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public ObservableCollection<WorkoutExercise> Exercises { get; set; }
        public string WorkoutId
        {
            set => LoadEverything(value);
        }
        public Workout Workout { get; set; }

        public async void LoadEverything(string workoutId)
        {
            Workout = await App.Database.GetWorkoutById(int.Parse(workoutId));
            StartTime = Workout.StartTime.TimeOfDay;
            EndTime = Workout.EndTime.TimeOfDay;
            Date = Workout.StartTime.Date;
            Title = Date.ToString("MM/dd/yyyy");
            await ExecuteLoadItemsCommand();
        }

        public Command LoadExercisesCommand { get; }
        public PreviousWorkoutViewModel()
        {
            Exercises = new ObservableCollection<WorkoutExercise>();
            LoadExercisesCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }
        public async Task ExecuteLoadItemsCommand()
        {
            if (Workout == null)
            {
                return;
            }

            try
            {
                if (Exercises.Count == 0)
                {
                    var sets = await App.Database.GetSetsByWorkout(Workout.Id);
                    var exercises = sets.GroupBy(s => s.ExerciseId);
                    foreach (var ex in exercises)
                    {
                        var workoutSets = new ObservableCollection<WorkoutSet>();
                        foreach (var set in ex)
                        {
                            workoutSets.Add(new WorkoutSet(set.ExerciseName, set.ExerciseType)
                            {
                                Id = set.Id,
                                ExerciseName = set.ExerciseName,
                                ExerciseType = set.ExerciseType,
                                Reps = set.Reps,
                                Weight = set.Weight,
                                Notes = set.Notes,
                                Distance = set.Distance,
                                Minutes = set.Minutes,
                                Seconds = set.Seconds
                            });
                        }
                        Exercises.Add(new WorkoutExercise(ex.Key,ex.FirstOrDefault().ExerciseName, ex.FirstOrDefault().ExerciseType, workoutSets));
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
