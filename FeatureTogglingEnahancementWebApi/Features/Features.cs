
using FeatureTogglingEnahancementWebApi.Interfaces;

namespace FeatureTogglingEnahancementWebApi.Features
{
    //the bad thing is that the hierarchy should be defined;
    public class FinalizationFeature : ToggleFeature
    { 
        public bool IsOn { get; set; }
        //public IList<ToggleFeature>? ChildFeatures { get; set; }
    }

    public class ScheduleModifyFeature : ToggleFeature
    {
        public bool IsOn { get; set; }
        //public IList<ToggleFeature>? ChildFeatures { get; set; }
    }

    public class ScheduleDisplayModesFeature : ToggleFeature
    {
        public bool IsOn { get; set; }
        //public IList<ToggleFeature>? ChildFeatures { get; set; }
    }

    public static class FeatureService
    {
        public static object CreateFeature(ToggleFeature feature)
        {
            Type featureType = feature.GetType();
            var o = Activator.CreateInstance(featureType);
            return o;
        }
    }
}
