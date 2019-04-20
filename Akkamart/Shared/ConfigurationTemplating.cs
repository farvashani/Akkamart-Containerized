using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Akka.Configuration;
using DotLiquid;

namespace Shared {
    public static class ConfigurationTemplating {
        private static IDictionary<string, object> ConvertToObjectDictionary (IDictionary dictionary) {
            var result = new Dictionary<string, object> ();
            foreach (DictionaryEntry entry in dictionary) {
                result.Add ((string) entry.Key, entry.Value.ToString ());
            }
            return result;
        }

        public static Config WithEnvironmentVariables (string templateText, Config fallback = null) {
            var template = Template.Parse (templateText);
            var environment = ConvertToObjectDictionary (Environment.GetEnvironmentVariables ());
            var configuration = ConfigurationFactory.ParseString (template.Render (Hash.FromDictionary (environment)));
            return configuration.WithFallback (fallback ?? Config.Empty);
        }
    }
}