using System;
using Akkatecture.Aggregates;
using Akkatecture.Core;
using Memberships;

namespace Credentials {
    public class CredentialState : AggregateState<CredentialRoot, CredentialId>,
        IApply<CredentialStoredEvent>,
        IApply<LoginResultResponse> {
            public CredentialState (CredentialId credentialId, IIdentity memberId, LastSuccessFullLoginAttempt lastSuccessFullLoginAttempt, LastUnSuccessFullLoginAttempt lastUnSuccessFullLoginAttempt) {
                this.CredentialId = credentialId;
                this.MemberId = memberId;
                this.LastSuccessFullLoginAttempt = lastSuccessFullLoginAttempt;
                this.LastUnSuccessFullLoginAttempt = lastUnSuccessFullLoginAttempt;

            }
            public CredentialId CredentialId { get; private set; }
            public IIdentity MemberId { get; private set; }
            public LastSuccessFullLoginAttempt LastSuccessFullLoginAttempt { get; private set; }
            public LastUnSuccessFullLoginAttempt LastUnSuccessFullLoginAttempt { get; private set; }

            public void Apply (CredentialStoredEvent aggregateEvent) {
                this.CredentialId = aggregateEvent.CredentialId;
                this.MemberId = aggregateEvent.MemberId;
            }

            public void Apply (LoginResultResponse evn) {
                if (evn.IsSucceed) {
                    this.MemberId = evn.MemberId;
                    this.LastSuccessFullLoginAttempt = new LastSuccessFullLoginAttempt (DateTime.UtcNow);
                } else {
                    this.MemberId = evn.MemberId;
                    this.LastUnSuccessFullLoginAttempt = new LastUnSuccessFullLoginAttempt (DateTime.UtcNow);
                }

            }
            public CredentialState () { }
        }
}