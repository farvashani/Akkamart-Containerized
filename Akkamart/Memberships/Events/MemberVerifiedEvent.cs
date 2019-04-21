using Akkatecture.Aggregates;
using Akkatecture.Events;
using Memberships;

namespace Memberships {
    public class MemberVerifiedEvent : AggregateEvent<MemberAggregate, MemberId> {
        public MemberVerifiedEvent (bool isSucceed, MemberId memberId) {
            this.IsSucceed = isSucceed;
            this.MemberId = memberId;

        }
        public bool IsSucceed { get; set; }
        public MemberId MemberId { get; set; }
    }
}