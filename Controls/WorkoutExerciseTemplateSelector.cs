using WeightLiftTracker.Models;

namespace WeightLiftTracker.Controls
{
    public class WorkoutExerciseTemplateSelector : DataTemplateSelector
    {
        public DataTemplate WeightExerciseTemplate { get; set; }
        public DataTemplate CardioExerciseTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((WorkoutExercise)item).ExerciseType == 0 ? WeightExerciseTemplate : CardioExerciseTemplate;
        }
    }
}
