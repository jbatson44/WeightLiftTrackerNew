using WeightLiftTracker.ViewModels;

namespace WeightLiftTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PreviousWorkoutPage : ContentPage
    {
        public PreviousWorkoutPage()
        {
            InitializeComponent();
            BindingContext = new PreviousWorkoutViewModel();
        }
    }
}