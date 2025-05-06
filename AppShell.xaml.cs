using WeightLiftTracker.Views;

namespace WeightLiftTracker
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(RoutineDetailPage), typeof(RoutineDetailPage));
            Routing.RegisterRoute(nameof(ExerciseDetailPage), typeof(ExerciseDetailPage));
            Routing.RegisterRoute(nameof(AddExerciseToRoutine), typeof(AddExerciseToRoutine));
            Routing.RegisterRoute(nameof(NewRoutinePage), typeof(NewRoutinePage));
            Routing.RegisterRoute(nameof(NewExercisePage), typeof(NewExercisePage));
            Routing.RegisterRoute(nameof(CurrentWorkoutPage), typeof(CurrentWorkoutPage));
            Routing.RegisterRoute(nameof(PreviousWorkoutPage), typeof(PreviousWorkoutPage));
        }
    }
}
