using Akka.Actor;
using Akka.Event;
using Shared;

namespace Memberships {
    public class Membership : ReceiveActor {
        private readonly ILoggingAdapter _log = Context.GetLogger ();

        public Membership () {
            Receive<WorkItem> (w => {
                _log.Info ($"[WorkItem]Got work to do {w.Id} - {w.Name}");
            });

        }
    }
}