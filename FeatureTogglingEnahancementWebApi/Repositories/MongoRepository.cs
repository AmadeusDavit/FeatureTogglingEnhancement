using System.Dynamic;
using FeatureTogglingEnahancementWebApi.Features;
using FeatureTogglingEnahancementWebApi.Interfaces;
using FeatureTogglingEnahancementWebApi.SubmitTool;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using MongoDB.Driver;

namespace FeatureTogglingEnahancementWebApi.Repositories
{
    //data accessor

    public class MongoRepository : IRepository
    {
        private const string connectionLink = "mongodb://localhost:27017";
        private const string databaseName = "test";
        private IMongoCollection<ToggleFeature> _collection;

        public MongoRepository()
        {
            var client = new MongoClient(connectionLink);
            var db = client.GetDatabase(databaseName);
            _collection = db.GetCollection<ToggleFeature>("Features");
            var a = _collection.CountDocuments(FilterDefinitionBuilder.Empty);
        }

        private FilterDefinitionBuilder<ToggleFeature> FilterDefinitionBuilder =
        new FilterDefinitionBuilder<ToggleFeature>();

        public async Task<IEnumerable<ToggleFeature>> GetAllFeaturesAsync()
        {
            var filter = FilterDefinitionBuilder.Empty;
            var featuresToReturn = (await (await _collection.FindAsync<ToggleFeature>(filter)).ToListAsync()).Select(p => FeatureService.CreateFeature(p));
            return (IEnumerable<ToggleFeature>)featuresToReturn;
        }

        public async Task<ToggleFeature> GetFeaturesByNameAsync(string name)
        {
            //var filter = FilterDefinitionBuilder.Eq(p => p.GetType, GetType);
            //temp
            var filter = FilterDefinitionBuilder.Empty;
            var featureToReturn = await _collection.FindAsync(filter);
            return await featureToReturn.SingleOrDefaultAsync();
        }
    }
}
