using System;
using System.IO;
using System.Threading;
using Akka.Actor;
using Akka.Configuration;
using Akka.Event;
using Messangers;
using Shared;
namespace Messanger {
    class Program {
        [Obsolete]
        static void Main (string[] args) {
            var sys = Common.CreateSystem (args[0]);

            sys.ActorOf<SmsMessanger> ("smsmessanger");

            Common.WaitForExit ();
            Common.Shutdown (sys);
        }
    }
}