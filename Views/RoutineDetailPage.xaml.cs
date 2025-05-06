using WeightLiftTracker.ViewModels;

namespace WeightLiftTracker.Views
{
    public partial class RoutineDetailPage : ContentPage
    {
        RoutineDetailViewModel _viewModel;
        public RoutineDetailPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new RoutineDetailViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}