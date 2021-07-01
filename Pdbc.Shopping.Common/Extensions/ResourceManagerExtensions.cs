using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;

namespace Pdbc.Shopping.Common.Extensions
{
    public static class ResourceManagerExtensions
    {
        /// <summary>
        /// Get All resources for a given language
        /// </summary>
        /// <param name="resourceManager">The resource manager you want the resources from</param>
        /// <param name="language">The language</param>
        /// <returns></returns>
        public static IDictionary<string, string> GetResources(this ResourceManager resourceManager, string language = null)
        {
            // Add Error Resources
            return resourceManager.CreateCaseInsensitiveSpecificResourceData(language);
        }

        /// <summary>
        /// Get All resources for a given language
        /// </summary>
        /// <param name="resourceManager">The resource manager you want the resources from</param>
        /// <param name="language">The language</param>
        /// <returns></returns>
        public static string GetResourceByKey(this ResourceManager resourceManager, string key, string language = null)
        {
            // Add Error Resources
            var errorResources = resourceManager.CreateCaseInsensitiveSpecificResourceData(language);

            var translation = errorResources.FirstOrDefault(kvp => kvp.Key.Equals(key, StringComparison.OrdinalIgnoreCase));
            return translation.Value;
        }


        private static IDictionary<string, string> CreateCaseInsensitiveSpecificResourceData(this ResourceManager resourceManager,
            string language)
        {
            return resourceManager.CreateSpecificResourceData(language, StringComparer.OrdinalIgnoreCase);
        }

        private static IDictionary<string, string> CreateSpecificResourceData(this ResourceManager resourceManager,
            string language,
            StringComparer comparer = null)
        {
            if (resourceManager == null)
                return new Dictionary<string, string>(comparer);

            var languageShort = language.ToCultureInfo();
            var resourceSet = resourceManager.GetResourceSet(languageShort, true, false);

            var data = new Dictionary<string, string>(comparer);
            if (resourceSet != null)
            {
                data = resourceSet
                    .Cast<DictionaryEntry>()
                    .ToDictionary(entry => entry.Key.ToString(), entry => entry.Value.ToString());
            }

            var parentResourceData = resourceManager.GetResourceSet(new CultureInfo(""), true, true)
                .Cast<DictionaryEntry>()
                .ToDictionary(x => x.Key.ToString(), x => x.Value.ToString());

            foreach (var entry in parentResourceData)
            {
                if (data.ContainsKey(entry.Key))
                    continue;

                data.Add(entry.Key, entry.Value);
            }

            return new Dictionary<string, string>(data, comparer);
        }
    }
}