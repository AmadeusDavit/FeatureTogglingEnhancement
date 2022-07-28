using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoSubmitTool.Models
{
    public record FeatureModel
    {
        public int FeatureId { get; set; }
        public string Name { get; set; }
    }
}
