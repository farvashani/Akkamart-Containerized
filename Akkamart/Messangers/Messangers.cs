using Akka.Actor;
using Akka.Event;
using Shared;

namespace Messangers {
    public class SmsMessanger : ReceiveActor {
        private readonly ILoggingAdapter _log = Context.GetLogger ();

        public SmsMessanger () {
            Receive<WorkItem> (w => {
                _log.Info ($"[WorkItem]Got work to do {w.Id} - {w.Name}");
            });

        }
    }

}