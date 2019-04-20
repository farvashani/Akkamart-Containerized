using System;
using Akka.Actor;
using Memberships;
using Shared;

namespace Memberships {
    class Program {
        [Obsolete]
        private static void Main (string[] args) {
            var sys = Common.CreateSystem (args[0]);

            sys.ActorOf<Membership> (MyActorNames.MembershipActorname);

            Common.WaitForExit ();
            Common.Shutdown (sys);
        }
    }
}