using Akkatecture.Aggregates;
using Akkatecture.Core;
using Akkatecture.Events;
using Credentials;

namespace Credentials {
    [EventVersion ("LoginResultResponse", 1)]
    public class LoginResultResponse : AggregateEvent<CredentialRoot, CredentialId> {
        public LoginResultResponse (bool isSucceed, IIdentity memberId) {
            this.IsSucceed = isSucceed;
            this.MemberId = memberId;

        }
        public bool IsSucceed { get; set; }
        public IIdentity MemberId { get; set; }
    }
}