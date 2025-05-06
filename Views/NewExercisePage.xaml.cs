using WeightLiftTracker.Models;
using WeightLiftTracker.ViewModels;

namespace WeightLiftTracker.Views
{
    public partial class NewExercisePage : ContentPage
    {
        public Exercise Item { get; set; }

        public NewExercisePage()
        {
            InitializeComponent();
            BindingContext = new NewExerciseViewModel();
        }
    }
}