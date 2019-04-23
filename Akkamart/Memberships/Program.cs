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

            var membershipActor = sys.ActorOf<MemberManager> (nameof (MemberManager).ToLower ());

            //     var q = false;
            //    // while (!q) {

            //         var memId = MemberId.New;
            //         var cmd = new CreateMemberCommand (memId, "09018119700");
            //         membershipActor.Tell (cmd);

            //         var qs = Console.ReadLine ();
            //         if (qs == "q") {
            //             q = true;
            //         }

            //         Console.ReadLine ();

            Common.WaitForExit ();
            Common.Shutdown (sys);
        }
    }
}