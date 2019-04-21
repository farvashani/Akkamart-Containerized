using Akkatecture.Core;
using Newtonsoft.Json;

namespace Credentials {
    public class CredentialId : Identity<CredentialId> {
        public CredentialId (string value) : base (value) { }

    }
}