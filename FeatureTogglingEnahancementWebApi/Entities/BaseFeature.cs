using FeatureTogglingEnahancementWebApi.Interfaces;

namespace FeatureTogglingEnahancementWebApi.Entities
{
    public class BaseFeature : ToggleFeature
    {
        private bool isOn;

        public bool IsOn
        {
            get => isOn;
            set => isOn = value;
        }
    }
}
