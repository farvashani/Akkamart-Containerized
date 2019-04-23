using System;
using System.IO;
using Akka.Actor;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;
using Shared;
using Shared.MainExtension;

namespace Sagas {
    class Program {
        [Obsolete]
        static void Main (string[] args) {
            var sys = Common.CreateSystem (args[0]);

            sys.ActorOf<SagasManager> (MyActorNames.CredentialActorname);

            Common.WaitForExit ();
            Common.Shutdown (sys);
        }
    }
}