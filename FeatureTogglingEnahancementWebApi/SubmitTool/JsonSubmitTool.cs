using FeatureTogglingEnahancementWebApi.Entities;
using FeatureTogglingEnahancementWebApi.Interfaces;
using FeatureTogglingEnahancementWebApi.SubmitTool.SubmitToolInterface;
using MongoDB.Driver;
using System.Text.Json;

namespace FeatureTogglingEnahancementWebApi.SubmitTool
{
    //ASK ABOUT CODE REPITITON
    public class JsonSubmitTool : ISubmitTool
    {
        //CHANGE THE PATH IF NEEDED ITS NOT ABSOULTE YET
        private const string pathToJsonFile = "C:/Users/dkazaryan/Desktop/FeatureToggling/ToggleFeaturesTest.txt";
        private const string connectionLink = "mongodb://localhost:27017";
        private const string databaseName = "features";
        private IMongoCollection<ToggleFeature> _collection;

        List<ToggleFeature>? items;

        public JsonSubmitTool()
        {
            var client = new MongoClient(connectionLink);
            var db = client.GetDatabase(databaseName);
            _collection = db.GetCollection<ToggleFeature>("features");
            LoadJson();
        }

        private FilterDefinitionBuilder<ToggleFeature> filterDefinitionBuilder =
        new FilterDefinitionBuilder<ToggleFeature>();

        public void LoadJson()
        {
            using (StreamReader r = new StreamReader(pathToJsonFile))
            {
                string json = r.ReadToEnd();
                items = JsonSerializer.Deserialize<List<ToggleFeature>>(json);
            }

        }

        //IList<BaseFeature> features)
        public async Task CreateManyFeaturesAsync()
        {
            await _collection.InsertManyAsync(items);
        }

        public async void CreateSingleFeatureAsync(ToggleFeature feature)
        {
            await _collection.InsertOneAsync(feature);
        }

        public async Task UpdateFeatureAsync(ToggleFeature feature)
        {
            var filter = filterDefinitionBuilder.Eq(p => p.GetType, GetType);
            await _collection.ReplaceOneAsync(filter, feature);
        }
    }
}
