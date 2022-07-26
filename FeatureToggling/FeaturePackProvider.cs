using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using Sky.Suite.Common.Infrastructure.Features.Interfaces;
using Sky.Suite.Common.Abstractions;
using Sky.Suite.Common.Abstractions.Resource;
using Sky.Suite.Common.Infrastructure.Resource;

namespace Sky.Suite.Common.Infrastructure.Features
{
    /// <inheritdoc />
    /// <summary>
    /// Feature pack provider picks values from feature.pack file
    /// </summary>
    public class FeaturePackProvider : IFeatureDataProvider
    {
        private readonly IAppSettingsProvider settingsProvider;
        private readonly IResourceAssemblyProvider assemblyProvider;

        public FeaturePackProvider(IAppSettingsProvider settingsProvider, IResourceAssemblyProvider assemblyProvider)
        {
            this.settingsProvider = settingsProvider;
            this.assemblyProvider = assemblyProvider;
        }
        public virtual IDictionary<Type, IFeature> GetFeatures(IDictionary<string, Type> requestedFeatures)
        {
            var packageData = GetFeaturesJson();

            var features = new Dictionary<Type, IFeature>();
            foreach (var record in packageData)
            {
                if (!requestedFeatures.ContainsKey(record.Key)) continue;

                Type type = requestedFeatures[record.Key];
                features[type] = JsonConvert.DeserializeObject(record.Value.ToString(), type) as IFeature; // Should throw exception if invalid data
            }

            return features;
        }

        protected virtual IDictionary<string, object> GetFeaturesJson()
        {
            string packName = this.settingsProvider.GetAppSetting("TogglingFeaturePackUri");
            if (string.IsNullOrEmpty(packName)) throw new Exception("Cannot obtain the name of feature package. Please check application configuration.");

            // Formalize name with correct pattern.
            packName = ResourceHelper.ToManifestResourceName(packName);

            // Try to find assembly to which particular resource belongs.
            Assembly sourceAssembly = this.assemblyProvider.GetResourceAssembly(packName);

            // Read content of requested package.
            string fileContent = ResourceHelper.GetEmbeddedResource(packName, sourceAssembly);

            var packageData = JsonConvert.DeserializeObject<Dictionary<string, object>>(fileContent);

            return packageData;
        }
    }
}
