using FeatureTogglingEnahancementWebApi.Interfaces;

namespace FeatureTogglingEnahancementWebApi.SubmitTool.SubmitToolInterface
{
    public interface ISubmitTool
    {
        Task UpdateFeatureAsync(ToggleFeature feature);
        void CreateSingleFeatureAsync(ToggleFeature feature);
        Task CreateManyFeaturesAsync();
    }
}
