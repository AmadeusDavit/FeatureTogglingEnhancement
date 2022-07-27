using Microsoft.AspNetCore.Mvc;

namespace FeatureTogglingEnahancementWebApi.Interfaces
{
    public interface IRepository
    {
        Task<IEnumerable<ToggleFeature>> GetAllFeaturesAsync();
        Task<ToggleFeature> GetFeaturesByNameAsync(string name);
    }
}
