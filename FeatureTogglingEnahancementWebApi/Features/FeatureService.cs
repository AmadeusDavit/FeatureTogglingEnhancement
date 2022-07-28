
using FeatureTogglingEnahancementWebApi.Interfaces;

namespace FeatureTogglingEnahancementWebApi.Features
{
    /// <summary>
    /// Possible Null return if the name provided is wrong
    /// </summary>
    public static class FeatureService
    {
        public static ToggleFeature FeatureInit(string name)
        {
            Type t = Type.GetType($"FeatureTogglingEnahancementWebApi.Features.{name}");
            return (ToggleFeature?)Activator.CreateInstance(t);
        }
    }
}
