using Akkatecture.Commands;
using Akkatecture.Core;

namespace Credentials {

    public class StoreCredential : Command<CredentialRoot, CredentialId> {
        public StoreCredential (CredentialId aggregateId) : base (aggregateId) { }

        public StoreCredential (CredentialId credentialId,IIdentity memberId,
            string username, string password) : base (credentialId) {
            this.Username = username;
            this.Password = password;
            this.MemberId = memberId;
            this.CredentialId = credentialId;

        }
        public string Username { get; set; }
        public string Password { get; set; }
        public IIdentity MemberId { get; set; }
        public CredentialId CredentialId { get; set; }
    }
}