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
        public string Name { get; set; }

        private ToggleFeature? feature;
        public ToggleFeature? Feature
        {
            get
            {
                feature = FeatureService.FeatureInit(Name);
                return feature;
            }
            set => feature = FeatureService.FeatureInit(Name);
        }

        /*public FinalizationFeature? FinalizationFeature { get; set; }
        public ScheduleModifyFeature? ScheduleModifyFeature { get; set; }
        public ScheduleDisplayModesFeature? ScheduleDisplayModesFeature { get; set; }*/
    }
}
