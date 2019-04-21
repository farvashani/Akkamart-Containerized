using Akkatecture.Aggregates;
using Akkatecture.Events;
using Memberships;
namespace Memberships {
    [EventVersion ("MemberMobileChangedEvent", 1)]
    public class MemberMobileChangedEvent : AggregateEvent<MemberAggregate, MemberId> {
        public MobileNumber MobileNumber { get; internal set; }
    }
}