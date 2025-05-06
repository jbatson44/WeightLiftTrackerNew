using WeightLiftTracker.ViewModels;

namespace WeightLiftTracker.Views
{
    public partial class WorkoutLogPage : ContentPage
    {
        WorkoutLogViewModel _viewModel;

        public WorkoutLogPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new WorkoutLogViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}