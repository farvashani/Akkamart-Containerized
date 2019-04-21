using Akkatecture.Commands;

namespace Credentials {
    public class ValidateCredentialCommand : Command<CredentialRoot, CredentialId> {
        public ValidateCredentialCommand (CredentialId aggregateId) : base (aggregateId) { }

        public ValidateCredentialCommand (CredentialId aggregateId,
            string username, string password) : base (aggregateId) {
            this.Username = username;
            this.Password = password;

        }
        public string Username { get; private set; }
        public string Password { get; private set; }
    }
}