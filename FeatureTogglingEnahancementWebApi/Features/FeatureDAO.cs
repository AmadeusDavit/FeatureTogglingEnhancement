using AngleSharp.Dom;
using FeatureTogglingEnahancementWebApi.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FeatureTogglingEnahancementWebApi.Features
{
    [BsonIgnoreExtraElements]
    public class FeatureDAO
    {
        public int FeatureId { get; set; }
        public FinalizationFeature? FinalizationFeature { get; set; }
        public ScheduleModifyFeature? ScheduleModifyFeature { get; set; }
    }
}
