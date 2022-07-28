using FeatureTogglingEnahancementWebApi.SubmitTool;

namespace MongoSubmitTool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JsonSubmitTool tool = new JsonSubmitTool();
            tool.CreateManyFeaturesAsync().GetAwaiter().GetResult();
        }
    }
}