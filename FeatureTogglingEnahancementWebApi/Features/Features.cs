
using FeatureTogglingEnahancementWebApi.Interfaces;

namespace FeatureTogglingEnahancementWebApi.Features
{
    public class FinalizationFeature : FeatureAbs
    { 
        public bool IsOn { get; set; }
        public IList<FeatureAbs>? ChildFeatures { get; set; }
        public FeatureAbs Parent { get; set; }
    }

    public class ScheduleModifyFeature : FeatureAbs
    {
        public bool IsOn { get; set; }
        public IList<FeatureAbs>? ChildFeatures { get; set; }
        public FeatureAbs Parent { get; set; }
    }

    public class ScheduleDisplayModesFeature : FeatureAbs
    {
        public bool IsOn { get; set; }
        public IList<FeatureAbs>? ChildFeatures { get; set; }
        public FeatureAbs Parent { get; set; }
    }


    //????????
    public static class FeatureService
    {
        public static object CreateFeature(ToggleFeature feature)
        {
            Type featureType = feature.GetType();
            return Activator.CreateInstance(featureType);
        }
    }
}
