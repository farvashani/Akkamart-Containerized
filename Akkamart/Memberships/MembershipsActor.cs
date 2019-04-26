using Akka.Actor;
using Akka.Event;
using Shared;

namespace Memberships {
    public class MembershipsActor : ReceiveActor {
        private readonly ILoggingAdapter _log = Context.GetLogger ();

        public MembershipsActor () {
            Receive<WorkItem> (w => {
                _log.Info ($"[WorkItem]Got work to do {w.Id} - {w.Name}");

                Sender.Tell (w);
            });

            Receive<CreateMemberCommand> (cmd => {
                _log.Info ($"[MembershipsActor]Got command to {nameof(CreateMemberCommand)} With MobileNumber - {cmd.Mobilenumber}");
                

                MobileNumber mobilenumber = new MobileNumber (cmd.Mobilenumber);
                var @memberAddedEvnt = new MemberCreatedEvent (mobilenumber, cmd.AggregateId);
                Sender.Tell (memberAddedEvnt);
            });

        }
    }
}