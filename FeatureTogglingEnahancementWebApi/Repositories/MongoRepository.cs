using System.Dynamic;
using FeatureTogglingEnahancementWebApi.Features;
using FeatureTogglingEnahancementWebApi.Interfaces;
using FeatureTogglingEnahancementWebApi.SubmitTool;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace FeatureTogglingEnahancementWebApi.Repositories
{
    //data accessor

    public class MongoRepository : IRepository
    {
        private const string connectionLink = "mongodb://localhost:27017";
        private const string databaseName = "test";
        private IMongoCollection<FeatureDAO> _collection;

        public MongoRepository()
        {
            var client = new MongoClient(connectionLink);
            var db = client.GetDatabase(databaseName);
            _collection = db.GetCollection<FeatureDAO>("Features");
        }

        private FilterDefinitionBuilder<FeatureDAO> FilterDefinitionBuilder =
        new FilterDefinitionBuilder<FeatureDAO>();

        public async Task<IEnumerable<FeatureDAO>> GetAllFeaturesAsync()
        {
            var filter = FilterDefinitionBuilder.Empty;
            var featuresToReturn = await (await _collection.FindAsync<FeatureDAO>(filter)).ToListAsync();
            return featuresToReturn;
        }

        public async Task<ToggleFeature> GetFeaturesByNameAsync(string name)
        {
            //var filter = FilterDefinitionBuilder.Eq(p => p.GetType, GetType);
            //temp
            var filter = FilterDefinitionBuilder.Empty;
            var featureToReturn = await _collection.FindAsync(filter);
            return (ToggleFeature)await featureToReturn.SingleOrDefaultAsync();
        }
    }
}
