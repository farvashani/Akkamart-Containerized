using Akkatecture.Commands;
using Credentials;

namespace Credentialss {
    public class UnSuccessfullLoginResponse : Command<CredentialRoot, CredentialId> {
        public UnSuccessfullLoginResponse (CredentialId aggregateId) : base (aggregateId) { }

    }
}