using Akkatecture.Commands;

namespace Memberships {
    public class GenerateNewVerificationCode : Command<MemberAggregate, MemberId> {
        public GenerateNewVerificationCode (MemberId aggregateId) : base (aggregateId) {

        }

    }
}