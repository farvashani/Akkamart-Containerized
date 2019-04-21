using Akkatecture.Aggregates;

namespace Memberships {
    public class MemberStateResponse : AggregateEvent<MemberAggregate, MemberId> {
        public MemberStateResponse () { }

        public MemberStateResponse (MemberState memberState) {
            this.MemberState = memberState;

        }
        public MemberState MemberState { get; private set; }

    }
}