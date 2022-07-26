using FeatureTogglingEnahancementWebApi.Entities;
using FeatureTogglingEnahancementWebApi.Interfaces;
using FeatureTogglingEnahancementWebApi.SubmitTool;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace FeatureTogglingEnahancementWebApi.Repositories
{
    //data accessor

    public class MongoRepository : IRepository
    {
        //temp
        private JsonSubmitTool submit;
        //temp

        private const string connectionLink = "mongodb://localhost:27017";
        private const string databaseName = "features";
        private IMongoCollection<ToggleFeature> _collection;

        public MongoRepository()
        {
            var client = new MongoClient(connectionLink);
            var db = client.GetDatabase(databaseName);
            _collection = db.GetCollection<ToggleFeature>("features");
        }

        private FilterDefinitionBuilder<ToggleFeature> FilterDefinitionBuilder =
        new FilterDefinitionBuilder<ToggleFeature>();

        public async Task<IEnumerable<ToggleFeature>> GetAllFeaturesAsync()
        {
            submit = new JsonSubmitTool();
            await submit.CreateManyFeaturesAsync();
            //temp

            var filter = FilterDefinitionBuilder.Empty;
            var featuresToReturn = await _collection.FindAsync(filter);
            return await featuresToReturn.ToListAsync();
        }

        public async Task<ToggleFeature> GetFeaturesByNameAsync(string name)
        {
            var filter = FilterDefinitionBuilder.Eq(p => p.GetType, GetType);
            var featureToReturn = await _collection.FindAsync(filter);
            return await featureToReturn.SingleOrDefaultAsync();
        }
    }
}
