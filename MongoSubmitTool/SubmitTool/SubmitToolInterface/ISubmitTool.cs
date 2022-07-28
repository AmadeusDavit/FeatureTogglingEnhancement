using MongoSubmitTool.Models;

namespace FeatureTogglingEnahancementWebApi.SubmitTool.SubmitToolInterface
{
    public interface ISubmitTool
    {
        Task UpdateFeatureAsync(FeatureModel feature);
        void CreateSingleFeatureAsync(FeatureModel feature);
        Task CreateManyFeaturesAsync();
    }
}
