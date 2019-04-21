using Akkatecture.Commands;
using Memberships;
namespace Memberships {
    public class RequestNewVerificationCode : Command<MemberAggregate, MemberId> {
        public RequestNewVerificationCode (MemberId aggregateId) : base (aggregateId) { }
    }
}