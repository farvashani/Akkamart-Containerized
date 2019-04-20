using System;
using System.IO;
using System.Threading;
using Akka.Actor;
using Akka.Configuration;
using Akka.Event;
using Shared;

namespace Credentials {
    class Program {
        [Obsolete]
        static void Main (string[] args) {
            var sys = Common.CreateSystem (args[0]);

            sys.ActorOf<Credential> (MyActorNames.CredentialActorname);

            Common.WaitForExit ();
            Common.Shutdown (sys);
        }
    }
}