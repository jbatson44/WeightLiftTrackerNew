using WeightLiftTracker.ViewModels;

namespace WeightLiftTracker.Views
{
    public partial class AddExerciseToRoutine : ContentPage
    {
        public AddExerciseToRoutine()
        {
            InitializeComponent();
            BindingContext = new AddExerciseViewModel();
        }
    }
}