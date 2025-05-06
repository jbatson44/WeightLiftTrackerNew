using WeightLiftTracker.ViewModels;

namespace WeightLiftTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CurrentWorkoutPage : ContentPage
    {
        public CurrentWorkoutPage()
        {
            InitializeComponent();
            BindingContext = new CurrentWorkoutViewModel();
        }

        private void Entry_Focused(object sender, FocusEventArgs e)
        {
            Entry entry = (Entry)sender;
            entry.Text = "";
        }
    }
}