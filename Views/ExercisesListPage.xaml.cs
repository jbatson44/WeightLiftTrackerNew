using WeightLiftTracker.ViewModels;

namespace WeightLiftTracker.Views
{
    public partial class ExercisesListPage : ContentPage
    {
        ExercisesListViewModel _viewModel;

        public ExercisesListPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ExercisesListViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}