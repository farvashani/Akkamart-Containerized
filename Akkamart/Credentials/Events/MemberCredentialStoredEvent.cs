using Akkatecture.Aggregates;
using Akkatecture.Core;
using Akkatecture.Events;

namespace Credentials {

    [EventVersion ("MemberCredentilStored", 1)]
    public class MemberCredentialStoredEvent : AggregateEvent<CredentialRoot, CredentialId> {
        public MemberCredentialStoredEvent (IIdentity memberId) {
            this.MemberId = MemberId;
        }
        public IIdentity MemberId { get; set; }
        public CredentialId CredentialId { get; internal set; }
    }
}