using Akka.Actor;
using Akkatecture.Aggregates;
using Akkatecture.Commands;
using Shared.Services;

namespace Memberships {
    [ServiceMetaData (nameof (MemberManager))]
    public class MemberManager : AggregateManager<MemberAggregate, MemberId, Command<MemberAggregate, MemberId>> {

        // protected override IActorRef CreateAggregate (MemberId aggregateId) {
        //     var aggregateRef = Context.ActorOf (Props.Create<MemberAggregate> (() => new MemberAggregate (aggregateId)));
        //     Context.Watch (aggregateRef);
        //     return aggregateRef;
        // }
    }
}