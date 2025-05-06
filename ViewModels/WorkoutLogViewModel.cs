using System.Collections.ObjectModel;
using System.Diagnostics;
using WeightLiftTracker.Models;
using WeightLiftTracker.Views;

namespace WeightLiftTracker.ViewModels
{
    public class WorkoutLogViewModel : BaseViewModel
    {
        private Workout _selectedWorkout;

        public ObservableCollection<Workout> Workouts { get; }
        public Command LoadWorkoutsCommand { get; }
        public Command<Workout> ItemTapped { get; }
        public Command<Workout> DeleteWorkoutCommand { get; }

        public WorkoutLogViewModel()
        {
            Title = "Workout Log";
            Workouts = new ObservableCollection<Workout>();
            LoadWorkoutsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Workout>(OnItemSelected);
            DeleteWorkoutCommand = new Command<Workout>(DeleteWorkout);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Workouts.Clear();
                var workouts = await App.Database.GetAllWorkouts();
                workouts = workouts.OrderByDescending(w => w.StartTime).ToList();
                foreach (var workout in workouts)
                {
                    Workouts.Add(workout);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedWorkout = null;
        }

        public Workout SelectedWorkout
        {
            get => _selectedWorkout;
            set
            {
                SetProperty(ref _selectedWorkout, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewExercisePage));
        }

        async void OnItemSelected(Workout workout)
        {
            if (workout == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(PreviousWorkoutPage)}?workoutId={workout.Id}");
        }

        async void DeleteWorkout(Workout workout)
        {
            if (workout == null)
                return;

            try
            {
                await App.Database.DeleteSetsFromWorkout(workout.Id);
                
                int row = await App.Database.DeleteWorkout(workout);
                if (row > 0)
                {
                    Workouts.Remove(Workouts.FirstOrDefault(x => x.Id == workout.Id));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}