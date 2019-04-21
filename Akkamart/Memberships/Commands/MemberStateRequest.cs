using Akkatecture.Commands;

namespace Memberships {
    public class MemberStateRequest : Command<MemberAggregate, MemberId> {
        public MemberStateRequest (MemberId aggregateId) : base (aggregateId) { }
    }
}