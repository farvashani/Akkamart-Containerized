using System;
using System.IO;
using Akka.Configuration;
using Akkatecture.Clustering.Configuration;

namespace Shared {
    public class ConfigurationLoader {
        public static Akka.Configuration.Config Load (string confUrl) {

            var configTemplate = LoadConfig (confUrl);
            return configTemplate;

            // var developmentConfig = LoadConfig ("akka.Development.conf");
            // //var dockerConf = ConfigurationFactory.Empty.BootstrapFromDocker ();
            // // var config = ConfigurationTemplating.WithEnvironmentVariables (configTemplate);

            // return developmentConfig
            //     //.WithFallback (dockerConf)
            //     .WithFallback (config)
            //     .WithFallback (AkkatectureClusteringDefaultSettings.DefaultConfig ());
        }

        private static Akka.Configuration.Config LoadConfig (string configFile) {
            Console.WriteLine ($"$%%%%%%%%OWN_HOST%%%%%% : {Environment.GetEnvironmentVariable ("OWN_HOST")}");
            var basepath = AppDomain.CurrentDomain.BaseDirectory;
            if (!configFile.StartsWith (basepath))
                configFile = Path.Combine (basepath, configFile);

            if (File.Exists (configFile)) {
                string config = File.ReadAllText (configFile);
                config = config
                    .Replace ("{{OWN_HOST}}", Environment.GetEnvironmentVariable ("OWN_HOST") ??
                        (Environment.CommandLine.Contains ("--local") ?
                            "localhost" :
                            System.Net.Dns.GetHostName ()))
                    .Replace ("{{SEED_NODE_HOST}}", Environment.GetEnvironmentVariable ("SEED_NODE_HOST") ?? "localhost")
                    .Replace ("{{SEED_NODE_PORT}}", Environment.GetEnvironmentVariable ("SEED_NODE_PORT") ?? "8080")
                    .Replace ("{{SQLSERVER_CONNECTION}}", Environment.GetEnvironmentVariable ("SQLSERVER_CONNECTION") ?? "");
                Console.WriteLine (config);
                return ConfigurationFactory.ParseString (config);
            }
            return Akka.Configuration.Config.Empty;
        }
    }
}