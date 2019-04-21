using Akka.Actor;
using Akkatecture.Aggregates;
using Akkatecture.Commands;

namespace Memberships {
    public class MemberManager : AggregateManager<MemberAggregate, MemberId, Command<MemberAggregate, MemberId>> {

        // protected override IActorRef CreateAggregate (MemberId aggregateId) {
        //     var aggregateRef = Context.ActorOf (Props.Create<MemberAggregate> (() => new MemberAggregate (aggregateId)));
        //     Context.Watch (aggregateRef);
        //     return aggregateRef;
        // }
    }
}