using WeightLiftTracker.ViewModels;

namespace WeightLiftTracker.Views
{
    public partial class RoutinesPage : ContentPage
    {
        RoutinesViewModel _viewModel;

        public RoutinesPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new RoutinesViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}