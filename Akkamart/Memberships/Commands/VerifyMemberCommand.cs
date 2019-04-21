using Akkatecture.Commands;
using Memberships;

namespace Memberships {
    public class VerifyMemberCommand : Command<MemberAggregate, MemberId> {
        public string Code { get; set; }
        public VerifyMemberCommand (MemberId aggregateId, string code) : base (aggregateId) {
            Code = code;
        }
    }
}