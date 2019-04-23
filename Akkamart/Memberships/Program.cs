using System;
using System.IO;
using Akka.Actor;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;
using Shared;
using Shared.MainExtension;

namespace Memberships {
    class Program {
        public static IConfiguration Configuration { get; private set; }

        [Obsolete]
        private static void Main (string[] args) {

            // var elasticsearchUri = Configuration["ElasticsearchUri"];
            // Log.Logger = new LoggerConfiguration ()
            //     .Enrich.FromLogContext ()
            //     .MinimumLevel.Debug ()
            //     .WriteTo.Elasticsearch (new ElasticsearchSinkOptions (new Uri (elasticsearchUri)) {
            //         MinimumLogEventLevel = LogEventLevel.Debug,
            //             AutoRegisterTemplate = true,
            //     })
            //     .CreateLogger ();            

            var sys = Common.CreateSystem (args[0]);

            sys.ActorOf<Membership> (MyActorNames.MembershipActorname);

            Common.WaitForExit ();
            Common.Shutdown (sys);
        }
    }
}