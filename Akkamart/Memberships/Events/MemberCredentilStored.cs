using Akkatecture.Aggregates;
using Akkatecture.Events;

namespace Memberships {

    [EventVersion ("MemberCredentilStored", 1)]
    public class MemberCredentialStoredEvent : AggregateEvent<CredentialRoot, CredentialId> {
        public MemberCredentialStoredEvent (MemberId memberId) {
            this.MemberId = MemberId;
        }
        public MemberId MemberId { get; set; }
        public CredentialId CredentialId { get; internal set; }
    }
}