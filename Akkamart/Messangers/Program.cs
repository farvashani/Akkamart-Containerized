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

            var smsManager = sys.ActorOf<SmsManager>("SmsManager");

            //Temp Code
            var smsId = SmsId.New;
            var cmd = new SendSmsCommand(smsId,"09901359936","Salam");
            smsManager.Tell(cmd);

            Common.WaitForExit ();
            Common.Shutdown (sys);
        }
    }
}