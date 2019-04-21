using System.Reflection;
using Akkatecture.Commands;

namespace Memberships {
    public class CreateMemberCommand : Command<MemberAggregate, MemberId> {
        public CreateMemberCommand (MemberId aggregateId, string mobilenumber) : base (aggregateId) {
            Mobilenumber = mobilenumber;
        }
        public string Mobilenumber { get; private set; }
    }
}