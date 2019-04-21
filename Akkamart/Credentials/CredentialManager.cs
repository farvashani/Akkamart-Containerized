using Akka.Actor;
using Akkatecture.Aggregates;
using Akkatecture.Commands;

namespace Credentials {
    public class CredentialManager : AggregateManager<CredentialRoot, CredentialId, Command<CredentialRoot, CredentialId>> {
        public CredentialManager () { }

        protected override IActorRef FindOrCreate (CredentialId aggregateId) {
            var aggregate = Context.Child (aggregateId.Value);

            if (Equals (aggregate, ActorRefs.Nobody)) {
                aggregate = CreateAggregate (aggregateId);
            }

            return aggregate;
        }

        protected override IActorRef CreateAggregate (CredentialId aggregateId) {
            var aggregateRef = Context.ActorOf (Props.Create<CredentialRoot> (aggregateId), aggregateId.Value);
            Context.Watch (aggregateRef);
            return aggregateRef;
        }

    }
}