using Akkatecture.Aggregates;
using Akkatecture.Core;
using Akkatecture.Events;

namespace Credentials {

    [EventVersion ("CredentialStoredEvent", 1)]
    public class CredentialStoredEvent : AggregateEvent<CredentialRoot, CredentialId> {
        public CredentialStoredEvent (IIdentity memberId, CredentialId credentialId) {
            this.MemberId = memberId;
            this.CredentialId = credentialId;
        }
        public IIdentity MemberId { get; set; }
        public CredentialId CredentialId { get; internal set; }
    }

}