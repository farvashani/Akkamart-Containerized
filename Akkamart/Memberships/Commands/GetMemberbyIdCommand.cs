using Akkatecture.Commands;

namespace Memberships {
    public class GetMemberbyIdCommand : Command<MemberAggregate, MemberId> {
        public GetMemberbyIdCommand (MemberId aggregateId) : base (aggregateId) { }
    }
}