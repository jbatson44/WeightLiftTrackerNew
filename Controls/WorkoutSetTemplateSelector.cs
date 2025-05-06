using WeightLiftTracker.Models;

namespace WeightLiftTracker.Controls
{
    public class WorkoutSetTemplateSelector : DataTemplateSelector
    {
        public DataTemplate WeightSetTemplate { get; set; }
        public DataTemplate CardioSetTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((WorkoutSet)item).ExerciseType == 0 ? WeightSetTemplate : CardioSetTemplate;
        }
    }
}
