using Akkatecture.Commands;

namespace Credentials {
    public class SuccessfullLoginResponse : Command<CredentialRoot, CredentialId> {
        public SuccessfullLoginResponse (CredentialId aggregateId) : base (aggregateId) { }
    }
}