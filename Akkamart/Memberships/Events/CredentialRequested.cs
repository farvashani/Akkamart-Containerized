using Akkatecture.Aggregates;
using Akkatecture.Core;
using Akkatecture.Events;
namespace Memberships {

    [EventVersion ("CredentialRequested", 1)]
    public class CredentialRequested : AggregateEvent<MemberAggregate, MemberId> {
        public CredentialRequested (MemberId memberId, IIdentity credentialId) {
            this.MemberId = MemberId;
            this.CredentialId = credentialId;

        }
        public MemberId MemberId { get; private set; }
        public IIdentity CredentialId { get; private set; }
    }

}