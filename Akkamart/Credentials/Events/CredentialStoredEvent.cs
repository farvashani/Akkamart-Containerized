using Akkatecture.Aggregates;
using Akkatecture.Core;
using Akkatecture.Events;

namespace Credentials
{

    [EventVersion("CredentialStoredEvent", 1)]
    public class CredentialStoredEvent : AggregateEvent<CredentialRoot, CredentialId>
    {
        public CredentialStoredEvent(CredentialId credentialId, IIdentity memberId, Username username, Password password)
        {
            this.MemberId = memberId;
            this.CredentialId = credentialId;
            Username = username;
            Password = password;
        }
        public IIdentity MemberId { get; set; }
        public CredentialId CredentialId { get; internal set; }
        public Username Username { get; internal set; }
        public Password Password { get; internal set; }
    }

}