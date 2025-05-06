using WeightLiftTracker.Models;

namespace WeightLiftTracker.ViewModels
{
    public class ExerciseCategory
    {
        public string Name { get; set; }
    }
    public class NewExerciseViewModel : BaseViewModel
    {
        private string name;
        private List<ExerciseCategory> _exerciseCategories;
        private ExerciseCategory _selectedCategory;
        private List<ExerciseTypeEnum> _exerciseTypes;
        private ExerciseTypeEnum _selectedType;
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        public List<ExerciseCategory> ExerciseCategories
        {
            get => _exerciseCategories;
            set => SetProperty(ref _exerciseCategories, value);
        }
        public ExerciseCategory SelectedCategory
        {
            get => _selectedCategory;
            set => SetProperty(ref _selectedCategory, value);
        }
        public List<ExerciseTypeEnum> ExerciseTypes
        {
            get => _exerciseTypes;
            set => SetProperty(ref _exerciseTypes, value);
        }
        public ExerciseTypeEnum SelectedType
        {
            get => _selectedType;
            set => SetProperty(ref _selectedType, value);
        }
        public NewExerciseViewModel()
        {
            ExerciseCategories = new List<ExerciseCategory>();
            ExerciseCategories.Add(new ExerciseCategory
            {
                Name = "Chest"
            });
            ExerciseCategories.Add(new ExerciseCategory
            {
                Name = "Back"
            });
            ExerciseCategories.Add(new ExerciseCategory
            {
                Name = "Biceps"
            });
            ExerciseCategories.Add(new ExerciseCategory
            {
                Name = "Legs"
            });
            ExerciseCategories.Add(new ExerciseCategory
            {
                Name = "Triceps"
            });
            ExerciseCategories.Add(new ExerciseCategory
            {
                Name = "Shoulders"
            });
            ExerciseCategories.Add(new ExerciseCategory
            {
                Name = "Cardio"
            });
            ExerciseTypes = new List<ExerciseTypeEnum>
            {
                ExerciseTypeEnum.Weights,
                ExerciseTypeEnum.Cardio
            };
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(name) && SelectedCategory != null;
        }


        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Exercise exercise = new Exercise()
            {
                Id = 1,
                Name = name,
                Category = SelectedCategory.Name,
                Type = (int)SelectedType
            };

            await App.Database.SaveExerciseAsync(exercise);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
