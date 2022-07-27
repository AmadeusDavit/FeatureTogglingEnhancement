using FeatureTogglingEnahancementWebApi.Features;
using Microsoft.AspNetCore.Mvc;

namespace FeatureTogglingEnahancementWebApi.Interfaces
{
    public interface IRepository
    {
        Task<IEnumerable<FeatureDAO>> GetAllFeaturesAsync();
        Task<ToggleFeature> GetFeaturesByNameAsync(string name);
    }
}
