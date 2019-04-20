using Akka.Actor;
using Akka.Event;
using Shared;

namespace Credentials {
    public class Credential : ReceiveActor {
        private readonly ILoggingAdapter _log = Context.GetLogger ();

        public Credential () {
            Receive<WorkItem> (w => {
                _log.Info ($"[Credential] Got work to do {w.Id} - {w.Name}");
            });
        }
    }
}