using System;
using System.IO;
using System.Threading;
using Akka.Actor;
using Akka.Configuration;
using Akka.Event;
using Shared;
namespace Seed2 {
    class Program {
        static void Main (string[] args) {
            var sys = Common.CreateSystem (args[0]);

            Common.WaitForExit ();
            Common.Shutdown (sys);
        }
    }
}