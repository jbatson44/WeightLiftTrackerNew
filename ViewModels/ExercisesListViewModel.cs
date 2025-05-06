using System.Collections.ObjectModel;
using System.Diagnostics;
using WeightLiftTracker.Models;
using WeightLiftTracker.Views;

namespace WeightLiftTracker.ViewModels
{
    public class ExercisesListViewModel : BaseViewModel
    {
        private Exercise _selectedExercise;

        public ObservableCollection<ExerciseList> Exercises { get; }
        public Command LoadExercisesCommand { get; }
        public Command AddExerciseCommand { get; }
        public Command<Exercise> ItemTapped { get; }
        public Command<Exercise> DeleteExerciseCommand { get; }

        public ExercisesListViewModel()
        {
            Title = "Exercises";
            Exercises = new ObservableCollection<ExerciseList>();
            LoadExercisesCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Exercise>(OnItemSelected);
            DeleteExerciseCommand = new Command<Exercise>(DeleteExercise);

            AddExerciseCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Exercises.Clear();
                var categories = (await App.Database.GetAllExercises()).GroupBy(x=>x.Category);
                foreach (var category in categories)
                {
                    Exercises.Add(new ExerciseList(category.Key, new ObservableCollection<Exercise>(category.ToList())));
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
            SelectedItem = null;
        }

        public Exercise SelectedItem
        {
            get => _selectedExercise;
            set
            {
                SetProperty(ref _selectedExercise, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewExercisePage));
        }

        async void OnItemSelected(Exercise exercise)
        {
            if (exercise == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(ExerciseDetailPage)}?exerciseId={exercise.Id}");
        }

        async void DeleteExercise(Exercise exercise)
        {
            if (exercise == null)
                return;

            try
            {
                var rows = await App.Database.DeleteExercise(exercise);
                if (rows > 0)
                {
                    var exGroup = Exercises.SingleOrDefault(i => i.Category == exercise.Category);
                    exGroup.Remove(exGroup.SingleOrDefault(x=>x.Id == exercise.Id));
                    if (exGroup.Count <= 0)
                    {
                        Exercises.Remove(exGroup);
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