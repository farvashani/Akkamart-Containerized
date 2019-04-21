using Akkatecture.Aggregates;
using Akkatecture.Core;
using Akkatecture.Events;
namespace Memberships {

    [EventVersion ("CredentialStoredEvent", 1)]
    public class CredentialStoredEvent : AggregateEvent<MemberAggregate, MemberId> {
        public CredentialStoredEvent (MemberId memberId) {
            this.MemberId = MemberId;
        }
        public MemberId MemberId { get; set; }
        public IIdentity CredentialId { get; internal set; }
    }

}