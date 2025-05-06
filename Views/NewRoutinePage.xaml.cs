using WeightLiftTracker.Models;
using WeightLiftTracker.ViewModels;

namespace WeightLiftTracker.Views
{
    public partial class NewRoutinePage : ContentPage
    {
        public Routine Item { get; set; }

        public NewRoutinePage()
        {
            InitializeComponent();
            BindingContext = new NewRoutineViewModel();
        }
    }
}