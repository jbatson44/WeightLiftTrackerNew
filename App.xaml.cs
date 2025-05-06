using WeightLiftTracker.Services;

namespace WeightLiftTracker
{
    public partial class App : Application
    {
        static WorkoutRepository database;
        public static WorkoutRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new WorkoutRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LiftTracker.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
