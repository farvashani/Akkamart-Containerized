using Akkatecture.Commands;

namespace Memberships {
    public class MemberAuthenticated : Command<MemberAggregate, MemberId> {
        public MemberAuthenticated (MemberId aggregateId) : base (aggregateId) { }
    }
}