using System;
using Akkatecture.Aggregates;
using Akkatecture.Core;
using Memberships;

namespace Memberships {
    public class MemberState : AggregateState<MemberAggregate, MemberId>,
        IApply<MemberCreatedEvent>,
        IApply<MemberMobileChangedEvent>,
        IApply<VerificationCodeRequestedEvent>,
        IApply<MemberVerifiedEvent>,
        IApply<MemberLogedInEvent>,
        IApply<CredentialRequested>,
        IApply<CredentialStoredEvent> {

            public MemberState () { }

            public MemberState (MobileNumber mobilenumber,
                VerificationCode verificationCode,
                IsVerified isVerified,
                DateTime authenticatedSince) {
                this.Mobilenumber = mobilenumber;
                this.VerificationCode = verificationCode;
                this.IsVerified = isVerified;
                this.AuthenticatedSince = authenticatedSince;

            }
            public MobileNumber Mobilenumber { get; private set; }
            public VerificationCode VerificationCode { get; private set; }
            public IsVerified IsVerified { get; private set; }
            public LastSuccessfullLogin LastSuccessfullLogin { get; private set; }
            public DateTime AuthenticatedSince { get; private set; }
            public LastChangedCredential LastChangedCredential { get; private set; }
            public IIdentity CredentialId { get; private set; }

            public void Apply (MemberCreatedEvent aggregateEvent) {
                Mobilenumber = aggregateEvent.Mobilenumber;
                VerificationCode = new VerificationCode (DateTime.Now.Ticks.ToString ());
                IsVerified = new IsVerified (false);
            }

            public void Apply (CredentialStoredEvent aggregateEvent) {
                this.LastChangedCredential = new LastChangedCredential (DateTime.Now);
                this.CredentialId = aggregateEvent.CredentialId;
            }

            public void Apply (MemberMobileChangedEvent aggregateEvent) {
                this.Mobilenumber = aggregateEvent.MobileNumber;
            }
            public void Apply (CredentialRequested aggregateEvent) {
                this.CredentialId = aggregateEvent.CredentialId;
                this.CredentialId = aggregateEvent.CredentialId;
                this.LastChangedCredential = new LastChangedCredential (DateTime.Now);
            }

            public void Apply (VerificationCodeRequestedEvent aggregateEvent) {
                this.VerificationCode = aggregateEvent.VerificationCode;
            }

            public void Apply (MemberVerifiedEvent aggregateEvent) {
                this.IsVerified = new IsVerified (true);
            }

            public void Apply (MemberLogedInEvent aggregateEvent) {
                this.LastSuccessfullLogin = new LastSuccessfullLogin (DateTime.Now);
            }
        }
}