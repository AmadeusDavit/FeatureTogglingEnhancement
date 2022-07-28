using FeatureTogglingEnahancementWebApi.SubmitTool.SubmitToolInterface;
using MongoDB.Driver;
using MongoSubmitTool.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace FeatureTogglingEnahancementWebApi.SubmitTool
{
    //ASK ABOUT CODE REPITITON
    public class JsonSubmitTool : ISubmitTool
    {
        //CHANGE THE PATH IF NEEDED ITS NOT ABSOULTE YET
        private const string pathToJsonFile = "C:/Users/dkazaryan/Desktop/ToMongo.txt";
        private const string connectionLink = "mongodb://localhost:27017";
        private const string databaseName = "test";
        private IMongoCollection<FeatureModel> _collection;

        public JsonSubmitTool()
        {
            var client = new MongoClient(connectionLink);
            var db = client.GetDatabase(databaseName);
            _collection = db.GetCollection<FeatureModel>("Features");
            LoadJson();
        }

        private FilterDefinitionBuilder<FeatureModel> filterDefinitionBuilder =
        new FilterDefinitionBuilder<FeatureModel>();

        List<FeatureModel> a;

        private void LoadJson()
        {
            string json;
            using (StreamReader r = new StreamReader(pathToJsonFile))
            {
                json = r.ReadToEnd();
                a = System.Text.Json.JsonSerializer.Deserialize<List<FeatureModel>>(json);
            }
        }

        //IList<BaseFeature> features)
        public async Task CreateManyFeaturesAsync()
        {
            await _collection.InsertManyAsync(a);
        }

        public async void CreateSingleFeatureAsync(FeatureModel feature)
        {
            await _collection.InsertOneAsync(feature);
        }

        public async Task UpdateFeatureAsync(FeatureModel feature)
        {
            //var filter = filterDefinitionBuilder.Eq(p => p.GetType, GetType);
            var filter = filterDefinitionBuilder.Empty;
            await _collection.ReplaceOneAsync(filter, feature);
        }
    }
}
