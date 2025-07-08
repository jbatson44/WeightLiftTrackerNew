using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using WeightLiftTracker.Views;

namespace WeightLiftTracker
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density, WindowSoftInputMode = SoftInput.AdjustResize)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var rootView = Window.DecorView.FindViewById(Android.Resource.Id.Content);
            rootView.ViewTreeObserver.GlobalLayout += (sender, args) =>
            {
                var rect = new Android.Graphics.Rect();
                rootView.GetWindowVisibleDisplayFrame(rect);

                int screenHeight = rootView.RootView.Height;
                int keypadHeight = screenHeight - rect.Bottom;

                System.Diagnostics.Debug.WriteLine($"Keyboard height: {keypadHeight}");

                // Threshold: if keyboard is open
                bool isKeyboardOpen = keypadHeight > screenHeight * 0.15;

                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    var currentPage = App.Current?.MainPage?.Navigation?.NavigationStack?.LastOrDefault();
                    if (currentPage is CurrentWorkoutPage mainPage)
                    {
                        await Task.Delay(50); // allow keyboard to settle
                        mainPage.UpdatePaddingForKeyboard(isKeyboardOpen ? keypadHeight : 0);
                    }
                });
            };
        }
    }
}
