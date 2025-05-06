using System.Collections.ObjectModel;
using System.Diagnostics;
using WeightLiftTracker.Models;
using WeightLiftTracker.Views;

namespace WeightLiftTracker.ViewModels
{
    [QueryProperty(nameof(RoutineId), "routineId")]
    public class RoutineDetailViewModel : BaseViewModel
    {
        public ObservableCollection<Exercise> Exercises { get; }
        public Command LoadExercisesCommand { get; }
        public Command AddExerciseCommand { get; }
        public Command StartWorkoutCommand { get; }
        public Command<Exercise> ItemTapped { get; }
        public Command<Exercise> DeleteExerciseCommand { get; }
        public string RoutineId
        {
            set => LoadEverything(value);
        }
        public Routine Routine { get; set; }

        public async void LoadEverything(string routineId)
        {
            Routine = await App.Database.GetRoutineById(int.Parse(routineId));
            Title = Routine.Name;
            IsBusy = true;
        }

        public RoutineDetailViewModel()
        {
            Title = "None";
            Exercises = new ObservableCollection<Exercise>();
            LoadExercisesCommand = new Command(async () => await ExecuteLoadItemsCommand());
            DeleteExerciseCommand = new Command<Exercise>(DeleteExercise);

            ItemTapped = new Command<Exercise>(OnItemSelected);

            AddExerciseCommand = new Command(OnAddItem);
            StartWorkoutCommand = new Command(StartWorkout);


        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            if (Routine == null)
            {
                IsBusy = false;
                return;
            }


            try
            {
                Exercises.Clear();
                var exercises = await App.Database.GetExercisesByRoutine(Routine.Id);
                foreach (var exercise in exercises)
                {
                    Exercises.Add(exercise);
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
        async void DeleteExercise(Exercise exercise)
        {
            if (exercise == null)
                return;

            try
            {
                await App.Database.RemoveExerciseFromRoutine(exercise.Id, Routine.Id);
                Exercises.Remove(Exercises.SingleOrDefault(i => i.Id == exercise.Id));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync($"{nameof(AddExerciseToRoutine)}?routineId={Routine.Id}");
        }
        private async void StartWorkout(object obj)
        {
            await Shell.Current.GoToAsync($"{nameof(CurrentWorkoutPage)}?routineId={Routine.Id}");
        }

        async void OnItemSelected(Exercise exercise)
        {
            if (exercise == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(ExerciseDetailPage)}?exerciseId={exercise.Id}");
        }
    }
}