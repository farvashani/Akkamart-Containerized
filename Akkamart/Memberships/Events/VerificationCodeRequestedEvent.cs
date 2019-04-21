using Akkatecture.Aggregates;
using Akkatecture.Events;
using Memberships;

namespace Memberships {
    [EventVersion ("VerificationCodeRequestedEvent", 1)]
    public class VerificationCodeRequestedEvent : AggregateEvent<MemberAggregate, MemberId> {
        public VerificationCodeRequestedEvent (
            VerificationCode verificationCode, MobileNumber mobileNumber) {
            this.VerificationCode = verificationCode;
            this.MobileNumber = mobileNumber;
        }
        public VerificationCode VerificationCode { get; set; }
        public MobileNumber MobileNumber { get; set; }
    }
}