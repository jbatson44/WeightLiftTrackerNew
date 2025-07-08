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
        int _lastKeyboardHeight = 0;
        public void UpdatePaddingForKeyboard(int keyboardHeight)
        {
            if (_lastKeyboardHeight == keyboardHeight)
                return; // no change, do nothing

            _lastKeyboardHeight = keyboardHeight;

            int clampedHeight = Math.Min(keyboardHeight, 300);
            MainGrid.Padding = new Thickness(0, 0, 0, clampedHeight);
        }
    }
}