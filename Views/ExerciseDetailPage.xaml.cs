using WeightLiftTracker.ViewModels;

namespace WeightLiftTracker.Views
{
    public partial class ExerciseDetailPage : ContentPage
    {
        ExerciseDetailViewModel _viewModel;
        public ExerciseDetailPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ExerciseDetailViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}