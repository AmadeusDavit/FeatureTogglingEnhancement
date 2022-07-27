
using FeatureTogglingEnahancementWebApi.Interfaces;

namespace FeatureTogglingEnahancementWebApi.Features
{
    //the bad thing is that the hierarchy should be defined;
    public class FinalizationFeature : ToggleFeature
    {
        private bool isOn = false;
        public IList<ToggleFeature>? ChildFeatures { get; set; }
        public bool IsOn { get => isOn; set => isOn = value; }
    }

    public class ScheduleModifyFeature : ToggleFeature
    {
        private bool isOn = false;
        public IList<ToggleFeature>? ChildFeatures { get; set; }
        public bool IsOn { get => isOn; set => isOn = value; }
    }

    public class ScheduleDisplayModesFeature : ToggleFeature
    {
        private bool isOn = false;
        public IList<ToggleFeature>? ChildFeatures { get; set; }
        public bool IsOn  {get => isOn; set => isOn = value; }
    }
}
