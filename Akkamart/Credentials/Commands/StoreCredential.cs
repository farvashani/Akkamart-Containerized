using Akkatecture.Commands;
using Akkatecture.Core;

namespace Credentials {

    public class StoreCredential : Command<CredentialRoot, CredentialId> {
        public StoreCredential (CredentialId aggregateId) : base (aggregateId) { }

        public StoreCredential (CredentialId credentialId,
            Username username, Password password, IIdentity memberId) : base (credentialId) {
            this.Username = username;
            this.Password = password;
            this.MemberId = memberId;
            this.CredentialId = credentialId;

        }
        public Username Username { get; set; }
        public Password Password { get; set; }
        public IIdentity MemberId { get; set; }
        public CredentialId CredentialId { get; set; }
    }
}