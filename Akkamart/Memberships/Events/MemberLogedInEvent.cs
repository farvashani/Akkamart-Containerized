using Akkatecture.Aggregates;
using Akkatecture.Events;
using Memberships;

namespace Memberships {
    public class MemberLogedInEvent : AggregateEvent<MemberAggregate, MemberId> {

    }
}